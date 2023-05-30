using Assets.Scripts.GameManagement.GameStates;
using UnityEngine;

namespace Assets.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance { get => _instance; }

        [SerializeField]
        private GameContext _context;
        private GameStateBase _state;

        private void Awake()
        {
            if (_instance == null)
                Init();
            else
                Destroy(this.gameObject);
        }

        private void Start()
        {
            _state = new MainMenuState(_context);
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
