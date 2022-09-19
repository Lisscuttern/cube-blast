using UnityEngine;

namespace PEAK
{
    public class GameManager : Singleton<GameManager>
    {
        #region SerializeFields

        [SerializeField] private GameSetting m_gameSetting;
        [SerializeField] private PlayerView m_playerView;
        [SerializeField] private EGameState m_eGameState;


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
            ChangeGameState(EGameState.NONE);
        }
        
        /// <summary>
        /// This function help for set game state
        /// </summary>
        /// <param name="eGameState"></param>
        public void ChangeGameState(EGameState eGameState)
        {
            m_eGameState = eGameState;
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

        /// <summary>
        /// This function return related e game state
        /// </summary>
        /// <returns></returns>
        public EGameState GetEGameState()
        {
            return m_eGameState;
        }
    }
}

