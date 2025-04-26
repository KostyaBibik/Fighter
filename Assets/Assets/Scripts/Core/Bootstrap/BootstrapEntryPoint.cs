using Enums;
using Zenject;

namespace Core
{
    public class BootstrapEntryPoint : IInitializable
    {
        private readonly ISceneLoader _sceneLoader;
    
        public BootstrapEntryPoint(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public async void Initialize()
        {
            await _sceneLoader.LoadSceneAsync(ESceneType.Fighter2D);
        }
    }
}