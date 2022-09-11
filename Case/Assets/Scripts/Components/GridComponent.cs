using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using PEAK;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridComponent : MonoBehaviour
{
    #region SerializeFields

    [Header("Game Area")]
    [SerializeField] private Vector2 m_size;

    [SerializeField] private Transform m_CubeRoot;
    [SerializeField] private Transform m_ReserveCubeRoot;

    [SerializeField] private SlotComponent m_slotComponent;
    [SerializeField] private List<SlotComponent> m_slots;
    
    

    #endregion

    #region Private Fields

    private PlayerView playerView => GameManager.Instance.GetPlayerView();

    #endregion

    private void Start()
    {
        CreateCubes();
        Invoke("CreateReverseCubes",5);
    }

    private void CreateCubes()
    {
        GameSetting gameSettings = GameManager.Instance.GetGameSetting(); 
        float slotXOffset = m_size.x / 2 * 90 + (m_size.x % 2 != 0 ? 0 : -0.125F);
        float slotYOffset = m_size.y / 2 * 90 + (m_size.y % 2 != 0 ? 0 : 0.125F);
        
        for (int y = 0; y < m_size.y; y++)
        {
            for (int x = 0; x < m_size.x; x++)
            {
                Vector3 targetLocalPosition = Vector3.zero;

                targetLocalPosition.x = x * 90 - slotXOffset;
                targetLocalPosition.y = y * 90 - slotYOffset;

                //List<CubeComponent> cubeComponents = gameSettings.Cubes;
                SlotComponent slotComponent = Instantiate(m_slotComponent, m_CubeRoot);
                m_slots.Add(slotComponent);
                slotComponent.transform.localPosition = targetLocalPosition;
                slotComponent.SetCubeCoordinate(x,y);
                // CubeComponent createdCube = Instantiate(cubeComponents[Random.Range(0,cubeComponents.Count)], m_CubeRoot);
                // createdCube.SetCubeCoordinate(x,y);
                // playerView.GetCreatedCubeComponents().Add(createdCube);
                //
                // createdCube.transform.localPosition = targetLocalPosition;
            }
        }

        for (int i = 0; i < m_slots.Count; i++)
        {
            List<CubeComponent> cubeComponents = gameSettings.Cubes;

            CubeComponent createdCube = Instantiate(cubeComponents[Random.Range(0,cubeComponents.Count)], m_CubeRoot);
            createdCube.transform.parent = m_slots[i].transform;
            m_slots[i].UpdateSlot(true);
            createdCube.SetSlotComponent(m_slots[i]);
            //createdCube.SetCubeCoordinate(x,y);
            playerView.GetCreatedCubeComponents().Add(createdCube);
                
            createdCube.transform.localPosition = Vector3.zero;
        }
    }

    private void CreateReverseCubes()
    {
        GameSetting gameSettings = GameManager.Instance.GetGameSetting(); 
        float slotXOffset = m_size.x / 2 * 90 + (m_size.x % 2 != 0 ? 0 : -0.125F);
        float slotYOffset = m_size.y / 2 * 90 + (m_size.y % 2 != 0 ? 0 : 0.125F);
        
        for (int y = 0; y < m_size.y; y++)
        {
            for (int x = 0; x < m_size.x; x++)
            {
                Vector3 targetLocalPosition = Vector3.zero;

                targetLocalPosition.x = x * 90 - slotXOffset;
                targetLocalPosition.y = y * 90 - slotYOffset;

                //List<CubeComponent> cubeComponents = gameSettings.Cubes;
                SlotComponent slotComponent = Instantiate(m_slotComponent, m_ReserveCubeRoot);
                m_slots.Add(slotComponent);
                slotComponent.transform.localPosition = targetLocalPosition;
                slotComponent.SetCubeCoordinate(x,y+9);
                // CubeComponent createdCube = Instantiate(cubeComponents[Random.Range(0,cubeComponents.Count)], m_CubeRoot);
                // createdCube.SetCubeCoordinate(x,y);
                // playerView.GetCreatedCubeComponents().Add(createdCube);
                //
                // createdCube.transform.localPosition = targetLocalPosition;
            }
        }

        for (int i = (int)(m_size.x * m_size.y); i < m_slots.Count; i++)
        {
            List<CubeComponent> cubeComponents = gameSettings.Cubes;

            CubeComponent createdCube = Instantiate(cubeComponents[Random.Range(0,cubeComponents.Count)], m_ReserveCubeRoot);
            createdCube.transform.parent = m_slots[i].transform;
            m_slots[i].UpdateSlot(true);
            createdCube.SetSlotComponent(m_slots[i]);
            //createdCube.SetCubeCoordinate(x,y);
            playerView.GetCreatedCubeComponents().Add(createdCube);
                
            createdCube.transform.localPosition = Vector3.zero;
        }
    }

     public IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);
        UpdateCubePositions();
    }

    /// <summary>
    /// This function help for update cube positions after select 
    /// </summary>
    public void UpdateCubePositions()
    {
        // for (int i = 0; i < playerView.GetCreatedCubeComponents().Count; i++)
        // {
        //     
        //     for (int j = 0; j < GetSlots().Count; j++)
        //     {
        //         CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[i];
        //         SlotComponent slotComponent = cubeComponent.GetSlotComponent();
        //         SlotComponent targetSlotComponent = GetSlots()[j];
        //         if (targetSlotComponent.GetIsSlotFull())
        //             continue;
        //         if (slotComponent.GetCubeCoordinates().y == targetSlotComponent.GetCubeCoordinates().y + 1)
        //         {
        //             targetSlotComponent.UpdateSlot(true);
        //             cubeComponent.transform.parent = targetSlotComponent.transform;
        //             cubeComponent.transform.DOLocalMoveY(0, 1);
        //         }
        //     }
        // }

        for (int i = 0; i < GetSlots().Count; i++)
        {
            SlotComponent targetSlotComponent = GetSlots()[i];
            if (targetSlotComponent.GetIsSlotFull())
                continue;
            for (int j = 0; j < playerView.GetCreatedCubeComponents().Count; j++)
            {
                CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[j];
                SlotComponent slotComponent = cubeComponent.GetSlotComponent();
                
                if (slotComponent.GetCubeCoordinates().y == targetSlotComponent.GetCubeCoordinates().y + 1)
                {
                    if (targetSlotComponent.GetIsSlotFull())
                        return;
                  
                    targetSlotComponent.UpdateSlot(true);
                    cubeComponent.transform.parent = targetSlotComponent.transform;
                    cubeComponent.transform.DOLocalMoveY(0, 1).OnComplete(() =>
                    {
                        cubeComponent.transform.localPosition = Vector3.zero;

                    });
                }
            }
        }
    }

    /// <summary>
    /// This function returen related slots
    /// </summary>
    /// <returns></returns>
    public List<SlotComponent> GetSlots()
    {
        return m_slots;
    }

}
