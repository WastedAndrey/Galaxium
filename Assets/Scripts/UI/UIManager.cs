using Assets.Scripts.ObjectManagement;
using Assets.Scripts.UI.ViewModels;
using Assets.Scripts.UI.ViewModels.Interfaces;
using Assets.Scripts.UI.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;
        public static UIManager Instance { get => _instance; }

        [SerializeField]
        private Canvas _canvas;

        private List<IView> _views = new List<IView>();

      /*  private void Awake()
        {
            
            if (_instance == null)
                Init();
            else
                Destroy(this.gameObject);

            DontDestroyOnLoad(this);
        }
        private void Init()
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }*/

        public async Task<T> OpenWindow<T>(string viewPath, bool closePreviousWindow = false) where T : IView
        {
            if (closePreviousWindow && _views.Count > 0)
                CloseTopWindow();

            AssetLoader assetLoader = new AssetLoader();
            T view = await assetLoader.Load<T>(viewPath, _canvas.transform);
            view.SetAssetLoader(assetLoader);
            view.Closed += ViewClosed;
            _views.Add(view);
            return view;
        }

        public T OpenWindow<T>(T view, bool closePreviousWindow = false) where T : IView
        {
            if (closePreviousWindow && _views.Count > 0)
                CloseTopWindow();

            view.SetParent(_canvas.transform);
            view.Closed += ViewClosed;
            _views.Add(view);
            return view;
        }

        public void CloseWindow(IView view)
        {
            view.Close();
        }
        public void CloseTopWindow()
        {
            _views[_views.Count - 1].Close();
        }

        private void ViewClosed(IView view)
        {
            view.Closed -= ViewClosed;

            if (_views.Contains(view))
                _views.Remove(view); 
        }
    }
}
