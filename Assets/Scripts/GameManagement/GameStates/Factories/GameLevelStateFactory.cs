
using Zenject;

namespace Assets.Scripts.GameManagement.GameStates.Factories
{
    public class GameLevelStateFactory : IFactory<GameContext, GameLevelState>
    {
        private DiContainer _container;

        [Inject]
        public GameLevelStateFactory(DiContainer container)
        {
            _container = container;
        }

        public GameLevelState Create(GameContext context)
        {
            var construtionParams = new object[] { _container.Resolve<GameContext>(), context };
            return _container.Instantiate<GameLevelState>(construtionParams);
        }
    }
}