
using Zenject;

namespace Assets.Scripts.GameManagement.GameStates.Factories
{
    public class MainMenuStateFactory : IFactory<GameContext, MainMenuState>
    {
        private DiContainer _container;

        [Inject]
        public MainMenuStateFactory(DiContainer container)
        {
            _container = container;
        }

        public MainMenuState Create(GameContext context)
        {
            var construtionParams = new object[] { _container.Resolve<GameContext>(), context };
            return _container.Instantiate<MainMenuState>(construtionParams);
        }
    }
}