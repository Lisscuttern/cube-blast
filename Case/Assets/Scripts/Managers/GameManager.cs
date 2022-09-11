using UnityEngine;

namespace PEAK
{
    public class GameManager : Singleton<GameManager>
    {
        #region SerializeFields

        [SerializeField] private GameSetting m_gameSetting;
        [SerializeField] private PlayerView m_playerView;


        #endregion

        #region Private Fields

        private LevelComponent levelComponent;

        #endregion

        private void Start()
        {
            InitializeWorld();
        }

        /// <summary>
        /// This function helper for initialize world.
        /// </summary>
        private void InitializeWorld()
        {
            Level currentLevel = LevelService.GetCurrentLevel();
            levelComponent = Instantiate(currentLevel.Prefab);
        }

        /// <summary>
        /// This function return related game setting
        /// </summary>
        /// <returns></returns>
        public PlayerView GetPlayerView()
        {
            return m_playerView;
        }
        
        /// <summary>
        /// This function return related game setting
        /// </summary>
        /// <returns></returns>
        public GameSetting GetGameSetting()
        {
            return m_gameSetting;
        }

        /// <summary>
        /// This function return related level component
        /// </summary>
        /// <returns></returns>
        public LevelComponent GetLevelComponent()
        {
            return levelComponent;
        }
    }
}

