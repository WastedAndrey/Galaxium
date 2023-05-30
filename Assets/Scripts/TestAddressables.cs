using Assets.Scripts.ObjectManagement;
using Assets.Scripts.Units;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddressables : MonoBehaviour
{
    public string assetId;

    public Transform objectParent;

    public UnitLink someObject;
    public List<GameObject> instances = new List<GameObject>();

    private AssetLoader assetLoader = new AssetLoader();

    [Button]
    private async void Load()
    {
        someObject = await assetLoader.Load<UnitLink>(assetId, objectParent);
        someObject.transform.SetParent(objectParent);
    }

    [Button]
    private async void LoadWithAutoUnload()
    {
        someObject = await assetLoader.Load<UnitLink>(assetId, objectParent);
        someObject.transform.SetParent(objectParent);
    }

    [Button]
    private void Unload()
    {
        assetLoader.Unload();
    }
    [Button]
    private void CreateInstances()
    {

    }
    [Button]
    private void DestroyInstances()
    {

    }

    [Button]
    private void FreeMemory()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
    }
}
