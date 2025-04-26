using Enums;
using UnityEngine;
using Zenject;

namespace Core
{
    [RequireComponent(typeof(Collider2D))]
    public class DoorTrigger : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        
        private readonly ESceneType TargetScene = ESceneType.Fighter3D;

        private bool _hasTriggered = false;
        private const string Player = "Player";

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private async void OnTriggerEnter2D(Collider2D other)
        {
            if (_hasTriggered)
                return;

            if (other.CompareTag(Player))
            {
                _hasTriggered = true;

                await _sceneLoader.LoadSceneAsync(TargetScene);
            }
        }
    }
}