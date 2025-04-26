using Zenject;

namespace Core
{
    public class PlayerInitializer : IInitializable
    {
        private readonly IPlayerFactory _factory;
        private readonly SceneHandler _sceneHandler;
        private readonly PlayerView _view;

        public PlayerInitializer(
            IPlayerFactory factory,
            SceneHandler sceneHandler,
            PlayerView view
        )
        {
            _factory = factory;
            _sceneHandler = sceneHandler;
            _view = view;
        }
        
        public void Initialize() =>
            InitializePlayer();
        
        private void InitializePlayer()
        {
            var markers = _sceneHandler.PlayerSpawnMarker;
            
            _factory.Create(_view, markers.position);
        }
    }
}