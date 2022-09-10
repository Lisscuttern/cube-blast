using System;
using System.Collections.Generic;
using PEAK;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridComponent : MonoBehaviour
{
    #region SerializeFields

    [Header("Game Area")]
    [SerializeField] private Vector2 m_size;

    [SerializeField] private Transform m_CubeRoot;
    [SerializeField] private SlotComponent m_slotComponent;
    [SerializeField] private List<SlotComponent> m_slots;

    #endregion

    #region Private Fields

    private PlayerView playerView => GameManager.Instance.GetPlayerView();

    #endregion

    private void Start()
    {
        CreateCubes();
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
    
}
