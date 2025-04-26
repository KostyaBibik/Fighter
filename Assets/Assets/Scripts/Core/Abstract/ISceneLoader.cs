using System.Threading.Tasks;
using Enums;

namespace Core
{
    public interface ISceneLoader
    {
        public Task LoadSceneAsync(ESceneType sceneType);
    }
}