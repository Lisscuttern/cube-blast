using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using PEAK;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridComponent : MonoBehaviour
{
    #region SerializeFields

    [Header("Game Area")] [SerializeField] private Vector2 m_size;

    [SerializeField] private Transform m_CubeRoot;
    [SerializeField] private Transform m_ReserveCubeRoot;

    [SerializeField] private SlotComponent m_slotComponent;
    [SerializeField] private List<SlotComponent> m_slots;

    [SerializeField] private List<SlotComponent> m_gameSlots;


    [SerializeField] private List<SlotComponent> emptySlots;
    [SerializeField] private List<CubeComponent> cubesToMove;

    #endregion

    #region Private Fields

    private PlayerView playerView => GameManager.Instance.GetPlayerView();

    #endregion

    private void Start()
    {
        CreateCubes();
        Invoke("CreateReverseCubes", 1);
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

                SlotComponent slotComponent = Instantiate(m_slotComponent, m_CubeRoot);
                m_slots.Add(slotComponent);
                m_gameSlots.Add(slotComponent);
                slotComponent.transform.localPosition = targetLocalPosition;
                slotComponent.SetCubeCoordinate(x, y);
            }
        }

        for (int i = 0; i < m_slots.Count; i++)
        {
            List<CubeComponent> cubeComponents = gameSettings.Cubes;

            CubeComponent createdCube = Instantiate(cubeComponents[Random.Range(0, cubeComponents.Count)], m_CubeRoot);
            createdCube.transform.parent = m_slots[i].transform;
            m_slots[i].UpdateSlot(true);
            createdCube.SetSlotComponent(m_slots[i]);
            m_slots[i].SetCubeComponent(createdCube);
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

                SlotComponent slotComponent = Instantiate(m_slotComponent, m_ReserveCubeRoot);
                m_slots.Add(slotComponent);
                slotComponent.transform.localPosition = targetLocalPosition;
                slotComponent.SetCubeCoordinate(x, y + 9);
            }
        }

        for (int i = (int)(m_size.x * m_size.y); i < m_slots.Count; i++)
        {
            List<CubeComponent> cubeComponents = gameSettings.Cubes;

            CubeComponent createdCube =
                Instantiate(cubeComponents[Random.Range(0, cubeComponents.Count)], m_ReserveCubeRoot);
            createdCube.transform.parent = m_slots[i].transform;
            m_slots[i].UpdateSlot(true);
            m_slots[i].SetCubeComponent(createdCube);
            createdCube.SetSlotComponent(m_slots[i]);
            playerView.GetCreatedCubeComponents().Add(createdCube);

            createdCube.transform.localPosition = Vector3.zero;
        }
    }

    public IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);
        //UpdateCubePositions();
        UpdateCubePositionsNew();
    }

    // private void CreateCubesToMove()
    // {
    //     for (int i = 0; i < playerView.GetCreatedCubeComponents().Count; i++)
    //     {
    //         Debug.Log("küp belirleme foruna girdi");
    //         CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[i];
    //         if (cubeComponent.GetSlotComponent().GetCubeCoordinates().y > emptySlots.First().GetCubeCoordinates().y &&
    //             cubeComponent.GetSlotComponent().GetCubeCoordinates().x == emptySlots.First().GetCubeCoordinates().x)
    //         {
    //             if (cubesToMove.Contains(cubeComponent))
    //                 return;
    //                 
    //             cubesToMove.Add(cubeComponent);
    //         }
    //     }
    // }


    private void CreateCubesToMove()
    {
        for (int i = 0; i < emptySlots.Count; i++)
        {
            for (int j = 0; j < playerView.GetCreatedCubeComponents().Count; j++)
            {
                CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[j];
                if (cubeComponent.GetSlotComponent().GetCubeCoordinates().y > emptySlots[i].GetCubeCoordinates().y &&
                    cubeComponent.GetSlotComponent().GetCubeCoordinates().x == emptySlots[i].GetCubeCoordinates().x)
                {
                    if (cubesToMove.Contains(cubeComponent))
                        continue;
                    
                    emptySlots.Add(cubeComponent.GetSlotComponent());
                    cubeComponent.GetSlotComponent().UpdateSlot(false);
                    cubesToMove.Add(cubeComponent);
                }
            }
        }
    }

    public void CubesMoveVol3()
    {
        for (int i = 0; i < cubesToMove.Count; i++)
        {
            SlotComponent targetSlot = new SlotComponent();

            for (int j = 0; j < GetSlots().Count; j++)
            {
                if (GetSlots()[j].GetCubeCoordinates().x == cubesToMove[i].GetSlotComponent().GetCubeCoordinates().x &&
                    GetSlots()[j].GetCubeCoordinates().y < cubesToMove[i].GetSlotComponent().GetCubeCoordinates().y)
                {
                    targetSlot = emptySlots[0];
                    if (targetSlot.GetIsSlotFull())
                        continue;

                    cubesToMove[i].GetSlotComponent().UpdateSlot(false);
                    cubesToMove[i].transform.parent = targetSlot.transform;
                    cubesToMove[i].transform.DOLocalMoveY(0, .5F);
                    targetSlot.UpdateSlot(true);
                }
            }
        }
    }

    private void CubesMoveVol3OLACAK()
    {
        for (int i = 0; i < emptySlots.Count; i++)
        {
            for (int j = 0; j < cubesToMove.Count; j++)
            {
                SlotComponent slotComponent = emptySlots[i];
                CubeComponent cubeComponent = cubesToMove[j];
                if (slotComponent.GetCubeCoordinates().x == cubeComponent.GetSlotComponent().GetCubeCoordinates().x &&
                    slotComponent.GetCubeCoordinates().y < cubeComponent.GetSlotComponent().GetCubeCoordinates().y)
                {
                    if(slotComponent.GetIsSlotFull())
                        continue;

                    cubeComponent.transform.parent = slotComponent.transform;
                    cubeComponent.transform.DOLocalMoveY(1, 0.2f);
                    cubeComponent.SetSlotComponent(slotComponent);
                    cubeComponent.GetSlotComponent().UpdateSlot(true);
                    //emptySlots.Remove(slotComponent);
                }
            }
        }
    }

    public void CubesMoveVol2()
    {
        for (int i = 0; i < cubesToMove.Count; i++)
        {
            SlotComponent targetSlot = new SlotComponent();

            for (int j = 0; j < GetSlots().Count; j++)
            {
             
                if (GetSlots()[j].GetCubeCoordinates().x == cubesToMove[i].GetSlotComponent().GetCubeCoordinates().x &&
                    GetSlots()[j].GetCubeCoordinates().y < cubesToMove[i].GetSlotComponent().GetCubeCoordinates().y)
                {
                    targetSlot = GetSlots()[j];
                    if (targetSlot.GetIsSlotFull())
                        continue;
                    //cubesToMove.Remove(cubesToMove[i]);

                    cubesToMove[i].GetSlotComponent().UpdateSlot(false);
                    cubesToMove[i].transform.parent = targetSlot.transform;

                    cubesToMove[i].transform.DOLocalMoveY(0, .1F);
                    targetSlot.UpdateSlot(true);
                }
            }
        }
    }

    public void Deneme()
    {
        Debug.Log("denemeye girdi");
        for (int i = 0; i < cubesToMove.Count; i++)
        {
            CubeComponent cubeComponent = cubesToMove[i];
            cubeComponent.UpdateCubePos();
        }
    }

    public void CubesMove()
    {
        for (int i = 0; i < emptySlots.Count; i++)
        {
            SlotComponent targetSlot = emptySlots[i];
            for (int j = 0; j < cubesToMove.Count; j++)
            {
                CubeComponent cubeComponent = cubesToMove[j];

                if (cubeComponent.GetSlotComponent().GetCubeCoordinates().x == targetSlot.GetCubeCoordinates().x)
                {
                    if (targetSlot.GetIsSlotFull())
                        continue;
                    Debug.Log("hareket ediyolar");
                    cubeComponent.transform.parent = targetSlot.transform;
                    cubeComponent.transform.DOLocalMoveY(0, 1);
                    targetSlot.UpdateSlot(true);
                    cubesToMove.Remove(cubeComponent);
                }
            }
            //emptySlots.Remove(targetSlot);
        }
        // cubesToMove.Clear();
        // emptySlots.Clear();
    }

    /// <summary>
    /// This function help for update cube positions after select 
    /// </summary>
    public void UpdateCubePositionsNew()
    {
        //List<SlotComponent> emptySlots = new List<SlotComponent>();
        for (int i = 0; i < GetSlots().Count; i++)
        {
            if (!GetSlots()[i].GetIsSlotFull())
            {
                if (emptySlots.Contains(GetSlots()[i]))
                    return;

                emptySlots.Add(GetSlots()[i]);
            }
        }


        Invoke("CreateCubesToMove", 2.5f);
        Invoke("CubesMoveVol3OLACAK",4f);
        //Invoke("CubesMoveVol2", 4);
        //Invoke("Deneme", 4);


        //CreateCubesToMove();


        // while (emptySlots.Count != 0)
        // {
        //     Debug.Log("while başladı");
        //     for (int i = 0; i < emptySlots.Count; i++)
        //     {
        //
        //         List<CubeComponent> createdCubes = playerView.GetCreatedCubeComponents();
        //         Debug.Log("empty slotları döndü");
        //
        //         for (int j = 0; j < createdCubes.Count; j++)
        //         {
        //             if (emptySlots.Count == 0)
        //                 break;
        //             if (emptySlots[i].GetCubeCoordinates().y == createdCubes[j].GetSlotComponent().GetCubeCoordinates().y - 1)
        //             {
        //                 
        //                 Debug.Log("son if e girdi küplerin parent ını değiştirdi tween hareketi başladı");
        //
        //                 //createdCubes[j].transform.localPosition = Vector3.zero;
        //                 
        //                 createdCubes[j].transform.parent = emptySlots[i].transform;
        //                 createdCubes[j].transform.DOLocalMoveY(0, 1);
        //                 emptySlots[i].UpdateSlot(true);
        //                 emptySlots.Remove(emptySlots[i]);
        //             }
        //         }
        //
        //         if (emptySlots.Count == 0)
        //             break;
        //     }
        // }
    }

    /// <summary>
    /// This function help for update cube positions after select 
    /// </summary>
    public void UpdateCubePositions()
    {
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