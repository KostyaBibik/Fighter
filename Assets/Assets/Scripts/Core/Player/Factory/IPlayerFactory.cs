using UnityEngine;

namespace Core
{
    public interface IPlayerFactory
    {
        public void Create(PlayerView view, Vector3 pos);
    }
}