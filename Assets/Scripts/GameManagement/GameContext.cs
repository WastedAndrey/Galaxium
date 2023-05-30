
using UnityEngine;

namespace Assets.Scripts.GameManagement
{
    [System.Serializable]
    public class GameContext
    {
        [SerializeField]
        private GameSettings _settings;

        public GameSettings Settings => _settings;
    }
}