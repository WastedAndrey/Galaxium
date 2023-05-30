namespace Assets.Scripts.GameManagement.GameStates
{
    public abstract class GameStateBase
    {
        protected GameContext _context;
        protected float _stateTime;

        public GameStateBase(GameContext context) => _context = context;
        public void Enter() { EnterInternal(); }
        protected abstract void EnterInternal();

        public void Update(float deltaTime)
        {
            _stateTime += deltaTime;
            UpdateInternal(deltaTime);
        }
        protected abstract void UpdateInternal(float deltaTime);
        public void Exit() { ExitInternal(); }
        protected abstract void ExitInternal();
    }
}