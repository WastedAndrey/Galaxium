
using Assets.Scripts.Weapons.WeaponFactories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject.Installers
{
    public class WeaponFactoryInstaller : MonoInstaller
    {
        [SerializeField]
        private WeaponFactoryBase[] weaponFactories = new WeaponFactoryBase[0];

        public override void InstallBindings()
        {

        }

#if UNITY_EDITOR
        [Button]
        private void LoadScriptableObjects()
        {
            string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(WeaponFactoryBase).Name);
            weaponFactories = new WeaponFactoryBase[guids.Length];

            for (int i = 0; i < guids.Length; i++)
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[i]);
                Object asset = UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(Object));

                if (asset is WeaponFactoryBase)
                {
                    weaponFactories[i] = asset as WeaponFactoryBase;
                }
            } 
        }
#endif
    }
}