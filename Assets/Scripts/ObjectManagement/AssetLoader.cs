
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Assets.Scripts.ObjectManagement
{
    public class AssetLoader
    {
        private GameObject _cachedObject;

        public async Task<T> Load<T>(string assetId)
        {
            InstantiationParameters parameters = new InstantiationParameters();
            return await LoadInternal<T>(assetId, parameters);
        }

        public async Task<T> Load<T>(string assetId, Transform parent)
        {
            InstantiationParameters parameters = new InstantiationParameters(parent, false);
            return await LoadInternal<T>(assetId, parameters);
        }

        private async Task<T> LoadInternal<T>(string assetId, InstantiationParameters parameters)
        {
            var handle = Addressables.InstantiateAsync(assetId, parameters);
            _cachedObject = await handle.Task;
            if (_cachedObject.TryGetComponent(out T component) == false)
                throw new NullReferenceException
                    ($"object of type {typeof(T)} is null on attempt to load it from addressables.");

            return component;
        }


        public void Unload()
        {
            if (_cachedObject == null)
                return;

            _cachedObject.SetActive(false);
            Addressables.ReleaseInstance(_cachedObject);
            _cachedObject = null;
        }
    }
}