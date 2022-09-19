using PEAK;
using UnityEngine;
using DG.Tweening;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColorType m_eColorType;
    [SerializeField] private ECubeType m_eCubeType;
    [SerializeField] private SlotComponent m_slotComponent;

    #endregion

    #region Private Fields

    private PlayerView playerView => GameManager.Instance.GetPlayerView();
    private bool duckCompolete = false;

    #endregion
    
    private void Update()
    {
        Duck();
    }

    /// <summary>
    /// This function help for hit raycast to the left side
    /// </summary>
    public void HitLeft()
    {
        RaycastHit hit;

        if (GetEColorType() == EColorType.NOCOLOR)
            return;
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

        if (playerView.GetRaycastCubes().Count > 0)
        {
            RaycastHit balloon;
            if (Physics.Raycast(transform.position, Vector3.left, out balloon, 95))
            {
                CubeComponent balloonCubeComponent = balloon.collider.GetComponent<CubeComponent>();
                
                if (balloonCubeComponent.GetECubeType() == ECubeType.BALLOON)
                {
                    if (playerView.GetRaycastCubes().Contains(balloonCubeComponent))
                        return;
                    playerView.GetRaycastCubes().Add(balloonCubeComponent);
                    playerView.GetCreatedCubeComponents().Remove(balloonCubeComponent);
                
                    balloonCubeComponent.GetSlotComponent().UpdateSlot(false);
                
                }
            }
        }
        Invoke("DestroyCubes", .6f);
    }

    /// <summary>
    /// This function help for hit raycast to the right side
    /// </summary>
    public void HitRight()
    {
        RaycastHit hit;

        if (GetEColorType() == EColorType.NOCOLOR)
            return;
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
        if (playerView.GetRaycastCubes().Count > 0)
        {
            RaycastHit balloon;
            if (Physics.Raycast(transform.position, Vector3.right, out balloon, 95))
            {
                CubeComponent balloonCubeComponent = balloon.collider.GetComponent<CubeComponent>();
                
                if (balloonCubeComponent.GetECubeType() == ECubeType.BALLOON)
                {
                    if (playerView.GetRaycastCubes().Contains(balloonCubeComponent))
                        return;

                    playerView.GetRaycastCubes().Add(balloonCubeComponent);
                    playerView.GetCreatedCubeComponents().Remove(balloonCubeComponent);
                
                    balloonCubeComponent.GetSlotComponent().UpdateSlot(false);
                
                }
            }
        }

        Invoke("DestroyCubes", .6f);
    }

    /// <summary>
    /// This function help for hit raycast to the up side
    /// </summary>
    public void HitUp()
    {
        RaycastHit hit;

        if (GetEColorType() == EColorType.NOCOLOR)
            return;
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
        if (playerView.GetRaycastCubes().Count > 0)
        {
            RaycastHit balloon;
            if (Physics.Raycast(transform.position, Vector3.up, out balloon, 95))
            {
                CubeComponent balloonCubeComponent = balloon.collider.GetComponent<CubeComponent>();
                
                if (balloonCubeComponent.GetECubeType() == ECubeType.BALLOON)
                {
                    if (playerView.GetRaycastCubes().Contains(balloonCubeComponent))
                        return;

                    playerView.GetRaycastCubes().Add(balloonCubeComponent);
                    playerView.GetCreatedCubeComponents().Remove(balloonCubeComponent);
                
                    balloonCubeComponent.GetSlotComponent().UpdateSlot(false);
                
                }
            }
        }
        Invoke("DestroyCubes", .6f);
    }

    /// <summary>
    /// This function help for hit raycast to the down side
    /// </summary>
    public void HitDown()
    {
        RaycastHit hit;
        if (GetEColorType() == EColorType.NOCOLOR)
            return;

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
        if (playerView.GetRaycastCubes().Count > 0)
        {
            RaycastHit balloon;
            if (Physics.Raycast(transform.position, Vector3.down, out balloon, 95))
            {
                CubeComponent balloonCubeComponent = balloon.collider.GetComponent<CubeComponent>();
                
                if (balloonCubeComponent.GetECubeType() == ECubeType.BALLOON)
                {
                    if (playerView.GetRaycastCubes().Contains(balloonCubeComponent))
                        return;

                    playerView.GetRaycastCubes().Add(balloonCubeComponent);
                    playerView.GetCreatedCubeComponents().Remove(balloonCubeComponent);
                
                    balloonCubeComponent.GetSlotComponent().UpdateSlot(false);
                
                }
            }
        }
        Invoke("DestroyCubes", .6f);
    }

    /// <summary>
    /// This function help for rocket animation
    /// </summary>
    private void RocketAnimation()
    {
        if (GetECubeType() == ECubeType.BASIC)
            return;
        
        if (GetECubeType() == ECubeType.DUCK)
            return;
        if (GetECubeType() == ECubeType.BALLOON)
            return;
        
        Sequence sequence = DOTween.Sequence();

        if (GetECubeType() == ECubeType.LEFT)
        {
            sequence.Join(transform.DOLocalMoveX(-5000, 5));
        }
        else
        {
            sequence.Join(transform.DOLocalMoveX(5000, 5));

        }

        sequence.OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    /// <summary>
    /// This function help for create duck mechanic
    /// </summary>
    private void Duck()
    {
        if (duckCompolete)
            return;
        if (GetEColorType() != EColorType.NOCOLOR)
            return;

        if (GetECubeType() == ECubeType.DUCK)
        {
            if (GetSlotComponent().GetCubeCoordinates().y == 0)
            {
                GetSlotComponent().UpdateSlot(false);
                LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
                levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(.2f));
                duckCompolete = true;
            }
        }
    }

    /// <summary>
    /// This function help for start rocket mechanic
    /// </summary>
    private void StartRocket()
    {
        if (GetECubeType() == ECubeType.BALLOON)
            return;
        if (GetEColorType() != EColorType.NOCOLOR)
            return;

        if (GetECubeType() == ECubeType.DUCK)
            return;

        GetSlotComponent().UpdateSlot(false);

        if (GetECubeType() == ECubeType.LEFT)
        {
            for (int i = 0; i < playerView.GetCreatedCubeComponents().Count; i++)
            {
                CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[i];
                if (GetSlotComponent().GetCubeCoordinates().y == cubeComponent.GetSlotComponent().GetCubeCoordinates().y)
                {
                    playerView.GetRocketTargetCubes().Add(cubeComponent);
                }
            }
            for (int j = 0; j <  playerView.GetRocketTargetCubes().Count; j++)
            {
                CubeComponent cubeComponent = playerView.GetRocketTargetCubes()[j];

                if (GetSlotComponent().GetCubeCoordinates().x > cubeComponent.GetSlotComponent().GetCubeCoordinates().x)
                {
                    playerView.GetRaycastCubes().Add(cubeComponent);
                    playerView.GetCreatedCubeComponents().Remove(cubeComponent);
                    cubeComponent.GetSlotComponent().UpdateSlot(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < playerView.GetCreatedCubeComponents().Count; i++)
            {
                CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[i];
                if (GetSlotComponent().GetCubeCoordinates().y == cubeComponent.GetSlotComponent().GetCubeCoordinates().y)
                {
                    playerView.GetRocketTargetCubes().Add(cubeComponent);
                }
            }
            
            for (int j = 0; j <  playerView.GetRocketTargetCubes().Count; j++)
            {
                CubeComponent cubeComponent = playerView.GetRocketTargetCubes()[j];

                if (GetSlotComponent().GetCubeCoordinates().x < cubeComponent.GetSlotComponent().GetCubeCoordinates().x)
                {
                    playerView.GetRaycastCubes().Add(cubeComponent);
                    playerView.GetCreatedCubeComponents().Remove(cubeComponent);
                    cubeComponent.GetSlotComponent().UpdateSlot(false);
                }
            }
        }
        Invoke("DestroyCubes", .6f);
    }

    /// <summary>
    /// This function help for destroy matched cubes and clear raycast cubes list
    /// </summary>
    private void DestroyCubes()
    {
        UpdateGoalValue();
        RocketAnimation();
        
        for (int i = 0; i < playerView.GetRaycastCubes().Count; i++)
        {
            if(playerView.GetRaycastCubes()[i] == null)
                continue;
            Destroy(playerView.GetRaycastCubes()[i].gameObject);
        }
        
        playerView.GetRaycastCubes().Clear();
        playerView.GetRocketTargetCubes().Clear();
        
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
                    
                    GameSetting gameSetting = GameManager.Instance.GetGameSetting();
                    RectTransform currentRect = gameSetting.ChangeRectTransform(cubeComponent.GetEColorType());
                    InterfaceManager.Instance.FlyCurrencyFromWorld(uiGoalItem.GetSlot(),Vector3.zero, currentRect);
                    if (uiGoalItem.GetGoalValue() == 0)
                        continue;
                    uiGoalItem.UpdateGoalValue();
                }
            }
        }
    }

    /// <summary>
    /// This function help for select cube with click
    /// </summary>
    public void Select()
    {
        if (GameManager.Instance.GetEGameState() != EGameState.NONE)
            return;
        if (!playerView.GetIsCanPlay())
            return;
        HitDown();
        HitLeft();
        HitUp();
        HitRight();
        StartRocket();
        //Duck();
        LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
        levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));

        GameSetting gameSetting = GameManager.Instance.GetGameSetting();
        Sequence sequence = DOTween.Sequence();
        Vector3 targetScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        sequence.Join(transform.DOPunchScale(targetScale * gameSetting.CubeScaleMultiply, gameSetting.CubeScaleDuration));
    }

    /// <summary>
    /// This function returen related e color type
    /// </summary>
    /// <returns></returns>
    public EColorType GetEColorType()
    {
        return m_eColorType;
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

    /// <summary>
    /// This function return related e cube type
    /// </summary>
    /// <returns></returns>
    public ECubeType GetECubeType()
    {
        return m_eCubeType;
    }
}