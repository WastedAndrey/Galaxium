
using Assets.Scripts.GameLevels;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameManagement
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private string _mainMenuSceneName;
        [SerializeField]
        private string _gameSceneName;
        [SerializeField]
        private List<GameLevelSettings> _gameLevelSettings;

        public List<GameLevelSettings> GameLevelSettings => _gameLevelSettings;

        public string MainMenuSceneName => _mainMenuSceneName;
        public string GameSceneName => _gameSceneName; 
    }
}