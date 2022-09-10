using UnityEngine;

namespace PEAK
{
    public class GameManager : Singleton<GameManager>
    {
        #region SerializeFields

        [SerializeField] private GameSetting m_gameSetting;

        #endregion


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

