using Assets.Scripts.ObjectManagement;
using Assets.Scripts.UI.ViewModels.Interfaces;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI.Views
{
    public abstract class View<T> : MonoBehaviour, IView where T : IViewModel
    {
        private enum ViewState
        { 
            Deactivated,
            Enabled,
            Disabled
        }

        protected T _viewModel;
        protected AssetLoader _assetLoader;

        public event Action<IView> Closed;
        private ViewState _viewState = ViewState.Deactivated;

        public void Init(T viewModel)
        {
            _viewModel = viewModel;
            InitInternal(viewModel);

            if (this.gameObject.activeInHierarchy == true)
            {
                Subscribe();
                _viewState = ViewState.Enabled;
            }
            else
                _viewState = ViewState.Disabled;
        }
        public void SetAssetLoader(AssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }
        protected virtual void InitInternal(T viewModel) { }
        protected virtual void Subscribe() { }
        protected virtual void Unsubscribe() { }

        protected void OnEnable()
        {
            if (_viewState == ViewState.Disabled)
            {
                Subscribe();
                OnEnableInternal();
                _viewState = ViewState.Enabled;
            }
        }

        protected virtual void OnEnableInternal() { }

        protected void OnDisable()
        {
            if (_viewState == ViewState.Enabled)
            {
                OnDisableInternal();
                Unsubscribe();
                _viewState = ViewState.Disabled;
            }    
        }
        protected virtual void OnDisableInternal() { }

        private void OnDestroy()
        {
            OnDestroyInternal();
            _viewModel.Dispose();
        }

        protected virtual void OnDestroyInternal() { }

        public async void Close()
        {
            await CloseProcess();
            Closed?.Invoke(this);
            
            if (_assetLoader != null)
                _assetLoader.Unload();
            else
                ObjectManager.Instanse.DestroyObject(this.gameObject);
            
        }
        protected async virtual Task CloseProcess() { }

        public void SetParent(Transform parent)
        {
            this.transform.SetParent(parent);
        }
    }

    public class ViewPathAttribute : System.Attribute
    {
        public string Path { get; private set; }

        public ViewPathAttribute(string path)
        {
            Path = path;
        }

    }
}