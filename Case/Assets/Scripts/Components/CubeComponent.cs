using PEAK;
using UnityEngine;
using DG.Tweening;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColorType m_EcolorType;
    [SerializeField] private SlotComponent m_slotComponent;
    
    [Header("Transforms")] 
    [SerializeField] private RectTransform m_canvas;
    [SerializeField] private RectTransform m_currencySlot;
        
    [Header("Prefabs")]
    [SerializeField] private RectTransform m_currencyPrefab;
    
    #endregion

    #region Private Fields

    private PlayerView playerView => GameManager.Instance.GetPlayerView();

    #endregion
    
    /// <summary>
    /// This function help for hit raycast to the left side
    /// </summary>
    public void HitLeft()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 95))
        {
            if (hit.collider.gameObject.tag != CommonTypes.CUBE_TAG)
                return;
            CubeComponent cubeComponent = hit.collider.GetComponent<CubeComponent>();

            if (cubeComponent.GetEColorType() == GetEColorType())
            {
                if (playerView.GetRaycastCubes().Contains(cubeComponent))
                    return;
                playerView.GetRaycastCubes().Add(cubeComponent);
                playerView.GetCreatedCubeComponents().Remove(cubeComponent);
                cubeComponent.Select();
                cubeComponent.GetSlotComponent().UpdateSlot(false);
            }
        }

        Invoke("DestroyCubes", .5f);
    }

    /// <summary>
    /// This function help for hit raycast to the right side
    /// </summary>
    public void HitRight()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, 95))
        {
            if (hit.collider.gameObject.tag != CommonTypes.CUBE_TAG)
                return;
            CubeComponent cubeComponent = hit.collider.GetComponent<CubeComponent>();

            if (cubeComponent.GetEColorType() == GetEColorType())
            {
                if (playerView.GetRaycastCubes().Contains(cubeComponent))
                    return;
                playerView.GetRaycastCubes().Add(cubeComponent);
                playerView.GetCreatedCubeComponents().Remove(cubeComponent);
                cubeComponent.Select();
                cubeComponent.GetSlotComponent().UpdateSlot(false);
            }
        }

        Invoke("DestroyCubes", .5f);
    }

    /// <summary>
    /// This function help for hit raycast to the up side
    /// </summary>
    public void HitUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 95))
        {
            if (hit.collider.gameObject.tag != CommonTypes.CUBE_TAG)
                return;
            CubeComponent cubeComponent = hit.collider.GetComponent<CubeComponent>();

            if (cubeComponent.GetEColorType() == GetEColorType())
            {
                if (playerView.GetRaycastCubes().Contains(cubeComponent))
                    return;
                playerView.GetRaycastCubes().Add(cubeComponent);
                playerView.GetCreatedCubeComponents().Remove(cubeComponent);
                cubeComponent.Select();
                cubeComponent.GetSlotComponent().UpdateSlot(false);
            }
        }
        Invoke("DestroyCubes", .5f);
    }

    /// <summary>
    /// This function help for hit raycast to the down side
    /// </summary>
    public void HitDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 95))
        {
            if (hit.collider.gameObject.tag != CommonTypes.CUBE_TAG)
                return;
            CubeComponent cubeComponent = hit.collider.GetComponent<CubeComponent>();

            if (cubeComponent.GetEColorType() == GetEColorType())
            {
                if (playerView.GetRaycastCubes().Contains(cubeComponent))
                    return;
                playerView.GetRaycastCubes().Add(cubeComponent);
                playerView.GetCreatedCubeComponents().Remove(cubeComponent);

                cubeComponent.Select();
                cubeComponent.GetSlotComponent().UpdateSlot(false);
            }
        }
        Invoke("DestroyCubes", .5f);
    }
    

    /// <summary>
    /// This function help for destroy matched cubes and clear raycast cubes list
    /// </summary>
    private void DestroyCubes()
    {
        UpdateGoalValue();
        for (int i = 0; i < playerView.GetRaycastCubes().Count; i++)
        {
            Destroy(playerView.GetRaycastCubes()[i].gameObject);
        }
        playerView.GetRaycastCubes().Clear();
    }

    /// <summary>
    /// This function help for update goal values
    /// </summary>
    private void UpdateGoalValue()
    {
        LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
        for (int i = 0; i < levelComponent.GetUiGoalPanel().GetUıGoalItems().Count; i++)
        {
            UIGoalItem uiGoalItem = levelComponent.GetUiGoalPanel().GetUıGoalItems()[i];
            for (int j = 0; j < playerView.GetRaycastCubes().Count; j++)
            {
                CubeComponent cubeComponent = playerView.GetRaycastCubes()[j];
                if (cubeComponent.GetEColorType() == uiGoalItem.GetEColor())
                {
                    uiGoalItem.UpdateGoalValue();
                }
            }
            
        }
    }
    
    /// <summary>
    /// This function helper for fly currency animation to target currency icon.
    /// </summary>
    /// <param name="worldPosition"></param>
    public void FlyCurrencyFromWorld(Vector3 worldPosition)
    {
        Camera targetCamera = CameraManager.Instance.GetCamera();
        Vector3 screenPosition = GameUtils.WorldToCanvasPosition(m_canvas, targetCamera, worldPosition);
        Vector3 targetScreenPosition = m_canvas.InverseTransformPoint(m_currencySlot.position);

        RectTransform createdCurrency = Instantiate(m_currencyPrefab, m_canvas);
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
    /// This function help for select cube with click
    /// </summary>
    public void Select()
    {
        HitDown();
        HitLeft();
        HitUp();
        HitRight();
        LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
        levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));
        GameSetting gameSetting = GameManager.Instance.GetGameSetting();
        Sequence sequence = DOTween.Sequence();
        Vector3 targetScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        sequence.Join(
            transform.DOPunchScale(targetScale * gameSetting.CubeScaleMultiply, gameSetting.CubeScaleDuration));
    }

    /// <summary>
    /// This function returen related e color type
    /// </summary>
    /// <returns></returns>
    public EColorType GetEColorType()
    {
        return m_EcolorType;
    }


    /// <summary>
    /// This function help for set slot component
    /// </summary>
    /// <param name="slotComponent"></param>
    public void SetSlotComponent(SlotComponent slotComponent)
    {
        m_slotComponent = slotComponent;
    }

    /// <summary>
    /// This function returen related slot component
    /// </summary>
    /// <returns></returns>
    public SlotComponent GetSlotComponent()
    {
        return m_slotComponent;
    }
}