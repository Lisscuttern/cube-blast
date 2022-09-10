using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PEAK
{
    public static class LevelService
    {
        /// <summary>
        /// This function help for initialize level
        /// </summary>
        public static void InitializeLevel()
        {
            GameSetting gameSetting = GameManager.Instance.GetGameSetting();
            int totalLevelCount = gameSetting.Levels.Length;
            int currentLevelID = PlayerPrefs.GetInt(CommonTypes.LEVEL_ID_DATA_KEY);
            
            Level targetLevel = gameSetting.Levels.SingleOrDefault(x => x.Id == currentLevelID % totalLevelCount);
            
            if (targetLevel == null)
            {
                Debug.Log($"Target Level is null! ID: {currentLevelID}");
                return;
            }
            LoadLevel(targetLevel.Name);
        }

        /// <summary>
        /// This function help for initialize next level
        /// </summary>
        public static void NextLevel()
        {
            GameSetting gameSetting = GameManager.Instance.GetGameSetting();

            int totalLevelCount = gameSetting.Levels.Length;
            int currentLevelID = PlayerPrefs.GetInt(CommonTypes.LEVEL_ID_DATA_KEY);
            int nextLevelId = currentLevelID + 1;
            
            Level targetLevel = gameSetting.Levels.SingleOrDefault(x => x.Id == nextLevelId % totalLevelCount);
            Level previousLevel = gameSetting.Levels.SingleOrDefault(x => x.Id == currentLevelID % totalLevelCount);
            
            if (targetLevel == null)
            {
                Debug.Log($"Target Level is null! ID: {nextLevelId}");
                return;
            }

            if (previousLevel == null)
            {
                Debug.Log($"Target Level is null! ID: {currentLevelID}");
                return;
            }
            
            PlayerPrefs.SetInt(CommonTypes.LEVEL_ID_DATA_KEY, nextLevelId);
            InitializeLevel();
        }
        
        /// <summary>
        /// This function helper for initialize current level.
        /// </summary>
        /// <param name="score"></param>
        public static void RetryLevel(int score = 0)
        {
            GameSetting gameSetting = GameManager.Instance.GetGameSetting();

            int totalLevelCount = gameSetting.Levels.Length;
            int currentLevelID = GetCachedLevel();

            Level targetLevel = gameSetting.Levels.SingleOrDefault(x => x.Id == currentLevelID % totalLevelCount);

            if (targetLevel == null)
            {
                Debug.Log($"Target Level is null! ID: {currentLevelID}");
                return;
            }
            InitializeLevel();
        }
        
        /// <summary>
        /// This function load scene with current level
        /// </summary>
        public static void LoadLevel(string name)
        {
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        }
        
        /// <summary>
        /// This function returns cached level id.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int GetCachedLevel(int offset = 0)
        {
            return PlayerPrefs.GetInt(CommonTypes.LEVEL_ID_DATA_KEY) + offset;
        }
     

        /// <summary>
        /// This function returns cached level id.
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Level GetCurrentLevel(int offset = 0)
        {
            GameSetting gameSetting = GameManager.Instance.GetGameSetting();
            int totalLevelCount = gameSetting.Levels.Length;
            int currentLevelID = GetCachedLevel();
            Level targetLevel = gameSetting.Levels.SingleOrDefault(x => x.Id == currentLevelID % totalLevelCount);
            return targetLevel;
        }
    }
}
