using UnityEngine;

namespace PEAK
{
    public class UIWinPanel : MonoBehaviour
    {
        #region SerializeFields
        
        [Header("Canvas Group")] 
        [SerializeField] private CanvasGroup m_winPanel;

        #endregion
        

        /// <summary>
        /// This function help for open win panel when complete level
        /// </summary>
        public void WinGame()
        {
            GameManager.Instance.ChangeGameState(EGameState.WIN);
            InterfaceManager.Instance.ChangePanelState(m_winPanel, true);
            GameManager.Instance.ChangeGameState(EGameState.NONE);
        }
        
        /// <summary>
        /// This function helper for next level.
        /// </summary>
        public void NextLevel()
        {
            LevelService.NextLevel();
        }
    }
}