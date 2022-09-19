using UnityEngine;

namespace PEAK
{
    public class UIWinPanel : MonoBehaviour
    {
        #region SerializeFields

        [SerializeField] private ParticleSystem m_confetti;

        [Header("Canvas Group")] 
        [SerializeField] private CanvasGroup m_winPanel;

        #endregion
        

        /// <summary>
        /// This function help for open win panel when complete level
        /// </summary>
        public void WinGame()
        {
            GameManager.Instance.ChangeGameState(EGameState.WIN);
            m_confetti.gameObject.SetActive(true);
            InterfaceManager.Instance.ChangePanelState(m_winPanel, true);
            m_confetti.Play();
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