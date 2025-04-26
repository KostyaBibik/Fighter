using System.Threading.Tasks;
using DataBase;
using Enums;
using Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ScenesConfig _sceneConfig;

        public SceneLoader(ScenesConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
        }

        public async Task LoadSceneAsync(ESceneType sceneType)
        {
            var sceneName = _sceneConfig.GetSceneName(sceneType);
            if (string.IsNullOrEmpty(sceneName))
            {
                Debug.LogError($"No scene name mapped for {sceneType}");
                return;
            }

            var loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            
            await loadOperation.ToObservable().ToTask();
        }
    }
}