
using UnityEngine;

namespace Assets.Scripts.ObjectManagement
{
    public class AssetAutoUnloader : MonoBehaviour
    {
        private AssetLoader _assetLoader;

        public void Init(AssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
        }

        private void OnDestroy()
        {
            _assetLoader?.Unload();
        }
    }
}