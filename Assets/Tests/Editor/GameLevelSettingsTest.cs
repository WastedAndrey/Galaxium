using Assets.Scripts.GameLevels;
using NUnit.Framework;
using System.Collections.Generic;

namespace Assets.Tests.Editor
{
    public class GameLevelSettingsTest
    {
        [Test]
        public void Test()
        {
            Dictionary<GameLevelSettings, string> scriptableObjects = AssetsFinder.GetObjects<GameLevelSettings>();

            foreach (GameLevelSettings item in scriptableObjects.Keys)
            {
                Assert.IsNotNull(item, scriptableObjects[item]);
            }
        }
    }

}
