using Assets.Scripts.GameManagement.GameStates;
using Assets.Scripts.GameManagement.GameStates.Factories;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance { get => _instance; }

        [SerializeField]
        private GameContext _context;
        private GameStateBase _state;


        [Inject]
        private MainMenuStateFactory _mainMenuStateFactory;


        private void Start1(bool bla)
        {
            _state = _mainMenuStateFactory.Create(_context);
            _state.Enter();
        }

        private void Init()
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            _state.Update(Time.deltaTime);
        }

        public void SetState(GameStateBase state)
        {
            _state.Exit();
            _state = state;
            _state.Enter();
        }
    }
}
