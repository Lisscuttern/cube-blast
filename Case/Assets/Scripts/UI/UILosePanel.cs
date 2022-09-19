using UnityEngine;

namespace PEAK
{
    public class UILosePanel : MonoBehaviour
    {
        #region SerializeFields

        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup m_losePanel;

        #endregion
    
    
        private void Update()
        {
            if (GameManager.Instance.GetEGameState() == EGameState.LOSE)
            {
                LoseGame();
            }
        }
        
        /// <summary>
        /// This function help for open win panel when complete level
        /// </summary>
        public void LoseGame()
        {
            InterfaceManager.Instance.ChangePanelState(m_losePanel, true);
        }
        
        /// <summary>
        /// This function helper for next level.
        /// </summary>
        public void RetryLevel()
        {
            LevelService.RetryLevel();
            GameManager.Instance.ChangeGameState(EGameState.NONE);
        }
    }
}