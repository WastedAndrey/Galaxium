using Assets.Scripts.GameManagement;
using Assets.Scripts.GameManagement.GameStates;
using Assets.Scripts.ObjectManagement;
using Assets.Scripts.UI;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MainInstaller", menuName = "Installers/MainInstaller")]
public class MainInstaller : ScriptableObjectInstaller<MainInstaller>
{
    [Header("Prefabs")]
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private ObjectManager _objectManager;
    [SerializeField]
    private UIManager _uiManager;
   

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromComponentInNewPrefab(_gameManager).AsSingle().NonLazy();
        Container.Bind<ObjectManager>().FromComponentInNewPrefab(_objectManager).AsSingle().NonLazy();
        Container.Bind<UIManager>().FromComponentInNewPrefab(_uiManager).AsSingle().NonLazy();


        Container.Bind<GameLevelState>().FromComponentInNewPrefab(_uiManager).AsSingle().NonLazy();
    }
}