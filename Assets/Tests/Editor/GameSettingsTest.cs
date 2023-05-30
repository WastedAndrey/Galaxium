using Assets.Scripts.GameManagement;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;

namespace Assets.Tests.Editor
{
    public class GameSettingsTest
    {
        [Test]
        public void Test()
        {
            Dictionary<GameSettings, string> scriptableObjects = AssetsFinder.GetObjects<GameSettings>();

            foreach (GameSettings item in scriptableObjects.Keys)
            {
                Assert.IsNotNull(item.GameLevelSettings, scriptableObjects[item]);
                Assert.Greater(0, item.GameLevelSettings.Count, scriptableObjects[item]);
                Assert.True(CheckSceneExists(item.MainMenuSceneName));
                Assert.True(CheckSceneExists(item.GameSceneName));
            }
        }

        public static bool CheckSceneExists(string sceneName)
        {
            EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;

            foreach (EditorBuildSettingsScene scene in scenes)
            {
                if (scene.path.Contains(sceneName))
                {
                    return true;
                }
            }

            return false;
        }
    }

}
