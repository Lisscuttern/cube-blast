using System;
using DG.Tweening;
using UnityEngine;

namespace PEAK
{
    public class InterfaceManager : Singleton<InterfaceManager>
    {
        #region SerializeFields
        
        [Header("Prefabs")]
        [SerializeField] private RectTransform m_currencyPrefab;

        [Header("Canvas Groups")]
        [SerializeField] private CanvasGroup m_winPanelCanvasGroup;

        [SerializeField] private UIWinPanel m_uiWinPanel;

        #endregion


        private void Start()
        {
            ChangePanelState(m_winPanelCanvasGroup,false);
        }

        /// <summary>
        /// This function helper for fly currency animation to target currency icon.
        /// </summary>
        /// <param name="worldPosition"></param>
        public void FlyCurrencyFromWorld(RectTransform slot,Vector3 worldPosition, RectTransform prefab)
        {
            LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
            Camera targetCamera = CameraManager.Instance.GetCamera();
            Vector3 screenPosition = GameUtils.WorldToCanvasPosition(levelComponent.GetCanvas(), targetCamera, worldPosition);
            Vector3 targetScreenPosition = levelComponent.GetCanvas().InverseTransformPoint(slot.position);

            RectTransform createdCurrency = Instantiate(prefab, levelComponent.GetCanvas());
            createdCurrency.anchoredPosition = screenPosition;

            Sequence sequence = DOTween.Sequence();

            sequence.Join(createdCurrency.transform.DOLocalMove(targetScreenPosition, 0.5F));

            sequence.OnComplete(() =>
            {
                Destroy(createdCurrency.gameObject);
            });

            sequence.Play();
        }
        
        /// <summary>
        /// This function help for change canvas group state
        /// </summary>
        /// <param name="state"></param>
        public void ChangePanelState(CanvasGroup canvasGroup, bool state)
        {
            if (DOTween.IsTweening(canvasGroup.GetInstanceID()))
                return;

            Sequence sequence = DOTween.Sequence();

            sequence.Join(canvasGroup.DOFade(state ? 1 : 0, 0.25F));
            sequence.OnComplete(() => { canvasGroup.blocksRaycasts = state; });

            sequence.SetId(canvasGroup.GetInstanceID());
            sequence.Play();
        }

        /// <summary>
        /// This function return related win panel canvas group
        /// </summary>
        /// <returns></returns>
        public CanvasGroup GetWinPanelCanvasGroup()
        {
            return m_winPanelCanvasGroup;
        }

        /// <summary>
        /// This function return realted ui win panel
        /// </summary>
        /// <returns></returns>
        public UIWinPanel GetUIWinPanel()
        {
            return m_uiWinPanel;
        }
    }
}


