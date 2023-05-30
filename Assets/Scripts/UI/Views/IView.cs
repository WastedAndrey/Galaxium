
using Assets.Scripts.ObjectManagement;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Views
{
    public interface IView
    {
        event Action<IView> Closed;
        void Close();
        void SetParent(Transform parent);
        void SetAssetLoader(AssetLoader assetLoader);
    }
}