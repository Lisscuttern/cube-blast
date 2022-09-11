using PEAK;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColorType m_EcolorType;
    [SerializeField] private SlotComponent m_slotComponent;
    

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
                // LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
                // //levelComponent.GetGridComponent().UpdateCubePositions();
                // levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));
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
                // LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
                // //levelComponent.GetGridComponent().UpdateCubePositions();
                // levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));
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
                // LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
                // //levelComponent.GetGridComponent().UpdateCubePositions();
                // levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));
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
                // LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
                // //levelComponent.GetGridComponent().UpdateCubePositions();
                // levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));
            }
        }
        Invoke("DestroyCubes", .5f);
    }

    /// <summary>
    /// This function help for update cube positions after matched cubes
    /// </summary>
    private void UpdateCubePosition()
    {

        float targetCube = GetSlotComponent().GetCubeCoordinates().y - 1;

        List<SlotComponent> slots = GameManager.Instance.GetLevelComponent().GetGridComponent().GetSlots();
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].GetCubeCoordinates().y == targetCube)
            {
                if (!slots[i].GetIsSlotFull())
                {
                    this.transform.parent = slots[i].transform;
                    transform.DOMoveY(slots[i].transform.localPosition.y, .5f);
                }
            }
        }
    }

    /// <summary>
    /// This function help for destroy matched cubes and clear raycast cubes list
    /// </summary>
    private void DestroyCubes()
    {
        for (int i = 0; i < playerView.GetRaycastCubes().Count; i++)
        {
            Destroy(playerView.GetRaycastCubes()[i].gameObject);
        }

        playerView.GetRaycastCubes().Clear();
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
        //LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
        //levelComponent.GetGridComponent().UpdateCubePositions();
        //levelComponent.GetGridComponent().StartCoroutine(levelComponent.GetGridComponent().Delay(1));
        //UpdateCubePosition();
        //BlastCube();
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