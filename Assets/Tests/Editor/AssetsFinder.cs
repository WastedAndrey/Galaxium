
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Tests.Editor
{
    public class AssetsFinder
    {
        public static Dictionary<T, string> GetObjects<T>() where T : ScriptableObject
        {
            StringBuilder _builder = new StringBuilder();
            _builder.Append("t:");
            _builder.Append(typeof(T).ToString());
            string[] guids = AssetDatabase.FindAssets(_builder.ToString());
            Dictionary<T, string> scriptableObjects = new Dictionary<T, string>();

            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                scriptableObjects.Add(AssetDatabase.LoadAssetAtPath<T>(assetPath), assetPath);
            }

            return scriptableObjects;
        }
    }
}