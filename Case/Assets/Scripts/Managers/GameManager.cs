using UnityEngine;

namespace PEAK
{
    public class GameManager : Singleton<GameManager>
    {
        #region SerializeFields

        [SerializeField] private GameSetting m_gameSetting;
        [SerializeField] private PlayerView m_playerView;


        #endregion


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
    }
}

