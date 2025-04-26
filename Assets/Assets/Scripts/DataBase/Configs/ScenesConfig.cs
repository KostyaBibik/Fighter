using Enums;
using UnityEngine;

namespace DataBase
{
    [CreateAssetMenu(fileName = nameof(ScenesConfig), menuName = "Game/Scene Configuration")]
    public class ScenesConfig : ScriptableObject
    {
        [SerializeField] private SceneMapping[] _sceneMappings;

        public string GetSceneName(ESceneType sceneType)
        {
            foreach (var mapping in _sceneMappings)
            {
                if (mapping.sceneType == sceneType)
                {
                    return mapping.sceneName;
                }
            }

            Debug.LogError($"No scene name mapping found for {sceneType}");
            return string.Empty;
        }
    }
}