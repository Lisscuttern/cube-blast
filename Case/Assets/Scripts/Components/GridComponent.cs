using PEAK;
using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Sequence = DG.Tweening.Sequence;

public class GridComponent : MonoBehaviour
{
    #region SerializeFields

    [Header("Game Area")] [SerializeField] private Vector2 m_size;

    [SerializeField] private Transform m_CubeRoot;
    [SerializeField] private Transform m_ReserveCubeRoot;

    [SerializeField] private SlotComponent m_slotComponent;
    [SerializeField] private List<SlotComponent> m_slots;

    [SerializeField] private List<SlotComponent> m_gameSlots;
    [SerializeField] private List<SlotComponent> m_reserveSlots;


    [SerializeField] private List<SlotComponent> emptySlots;
    [SerializeField] private List<CubeComponent> cubesToMove;

    #endregion

    #region Private Fields

    private PlayerView playerView => GameManager.Instance.GetPlayerView();
    private bool rocketIns = false;

    #endregion

    private void Start()
    {
        CreateCubes();
        Invoke("CreateReverseCubes", .5f);
    }

    private void Update()
    {
        InstantiateRocket();
    }

    /// <summary>
    /// This function help for create game cubes
    /// </summary>
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

            int balloonNumber = Random.Range(gameSettings.BalloonMinValue, gameSettings.BalloonMaxValue);
            int duckNumber = Random.Range(gameSettings.MinValue, gameSettings.MaxValue);
            int rocketNumber = Random.Range(gameSettings.MinValue, gameSettings.MaxValue);

            if (balloonNumber > gameSettings.BalloonMaxValue - 5)
            {
                CubeComponent createdCube = Instantiate(gameSettings.Balloon, m_CubeRoot);
                createdCube.transform.parent = m_slots[i].transform;
                m_slots[i].UpdateSlot(true);
                createdCube.SetSlotComponent(m_slots[i]);
                playerView.GetCreatedCubeComponents().Add(createdCube);
                createdCube.transform.localPosition = Vector3.zero;
            }
            
            else if (duckNumber < gameSettings.MinValue + 2)
            {
                CubeComponent createdCube = Instantiate(gameSettings.Duck, m_CubeRoot);
                createdCube.transform.parent = m_slots[i].transform;
                m_slots[i].UpdateSlot(true);
                createdCube.SetSlotComponent(m_slots[i]);
                playerView.GetCreatedCubeComponents().Add(createdCube);
                createdCube.transform.localPosition = Vector3.zero;
            }

            else if (rocketNumber > gameSettings.MaxValue - 3)
            {
                int numberForRocket = Random.Range(0, 2);
                if (numberForRocket == 1)
                {
                    CubeComponent createdCube = Instantiate(gameSettings.RocketSprites[0], m_CubeRoot);
                    createdCube.transform.parent = m_slots[i].transform;
                    m_slots[i].UpdateSlot(true);
                    createdCube.SetSlotComponent(m_slots[i]);
                    playerView.GetCreatedCubeComponents().Add(createdCube);
                    createdCube.transform.localPosition = Vector3.zero;
                }
                else
                {
                    CubeComponent createdCube = Instantiate(gameSettings.RocketSprites[1], m_CubeRoot);
                    createdCube.transform.parent = m_slots[i].transform;
                    m_slots[i].UpdateSlot(true);
                    createdCube.SetSlotComponent(m_slots[i]);
                    playerView.GetCreatedCubeComponents().Add(createdCube);
                    createdCube.transform.localPosition = Vector3.zero;
                }
            }

            else
            {
                CubeComponent createdCube =
                    Instantiate(cubeComponents[Random.Range(0, cubeComponents.Count)], m_CubeRoot);
                createdCube.transform.parent = m_slots[i].transform;
                m_slots[i].UpdateSlot(true);
                createdCube.SetSlotComponent(m_slots[i]);
                playerView.GetCreatedCubeComponents().Add(createdCube);
                createdCube.transform.localPosition = Vector3.zero;
            }
        }
    }

    /// <summary>
    /// This function help for create reserve cubes
    /// </summary>
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
                m_reserveSlots.Add(slotComponent);
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
            createdCube.SetSlotComponent(m_slots[i]);
            playerView.GetCreatedCubeComponents().Add(createdCube);

            createdCube.transform.localPosition = Vector3.zero;
        }
    }

    /// <summary>
    /// This function help for add spesific delay for find empty slots function
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);
        FindEmptySlots();
    }

    /// <summary>
    /// This function help for find cubes to move after matched function
    /// </summary>
    private void FindCubesToMove()
    {
        for (int i = 0; i < playerView.GetCreatedCubeComponents().Count; i++)
        {
            CubeComponent cubeComponent = playerView.GetCreatedCubeComponents()[i];

            for (int j = 0; j < emptySlots.Count; j++)
            {
                SlotComponent slotComponent = emptySlots[j];
                if (slotComponent.GetCubeCoordinates().x == cubeComponent.GetSlotComponent().GetCubeCoordinates().x &&
                    slotComponent.GetCubeCoordinates().y < cubeComponent.GetSlotComponent().GetCubeCoordinates().y)
                {
                    if (cubesToMove.Contains(cubeComponent))
                        continue;

                    emptySlots.Add(cubeComponent.GetSlotComponent());
                    cubeComponent.GetSlotComponent().UpdateSlot(false);
                    cubesToMove.Add(cubeComponent);
                }
            }
        }

        LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();
        levelComponent.GetUIMovesPanel().SetMoveValue();
    }

    /// <summary>
    /// This function help for instantiate rocket on game area
    /// </summary>
    private void InstantiateRocket()
    {
        if (!rocketIns)
            return;
        GameSetting gameSettings = GameManager.Instance.GetGameSetting();
        for (int i = 0; i < m_gameSlots.Count; i++)
        {
            SlotComponent slotComponent = m_gameSlots[i];
            if (slotComponent.gameObject.transform.childCount == 0)
            {
                int numberForRocket = Random.Range(0, 2);
                if (numberForRocket == 1)
                {
                    CubeComponent createdCube = Instantiate(gameSettings.RocketSprites[0], m_CubeRoot);
                    createdCube.transform.parent = slotComponent.transform;
                    createdCube.transform.localPosition = Vector3.zero;

                    slotComponent.UpdateSlot(true);
                    createdCube.SetSlotComponent(slotComponent);
                    playerView.GetCreatedCubeComponents().Add(createdCube);
                }
                else
                {
                    CubeComponent createdCube = Instantiate(gameSettings.RocketSprites[1], m_CubeRoot);
                    createdCube.transform.parent = slotComponent.transform;
                    createdCube.transform.localPosition = Vector3.zero;
                    slotComponent.UpdateSlot(true);
                    createdCube.SetSlotComponent(slotComponent);
                    playerView.GetCreatedCubeComponents().Add(createdCube);
                }
            }
        }

        rocketIns = false;
    }

    /// <summary>
    /// This function help for update cube positions after matched cube
    /// </summary>
    private void UpdateCubesPositions()
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
                    if (slotComponent.GetIsSlotFull())
                        continue;
                    
                    if(cubeComponent == null)
                        continue;
                    Sequence sequence = DOTween.Sequence();
                    cubeComponent.transform.parent = slotComponent.transform;
                    sequence.Join(cubeComponent.transform.DOLocalMoveY(1, 0.2f));
                    
                    sequence.Play();
                    cubeComponent.SetSlotComponent(slotComponent);
                    cubeComponent.GetSlotComponent().UpdateSlot(true);
                }
            }
        }

        emptySlots.Clear();
        cubesToMove.Clear();
        rocketIns = true;
    }

    /// <summary>
    /// This function help for update cube positions after select 
    /// </summary>
    public void FindEmptySlots()
    {
        for (int i = 0; i < GetSlots().Count; i++)
        {
            SlotComponent emptySlot = GetSlots()[i];
            if (!emptySlot.GetIsSlotFull())
            {
                if (emptySlots.Contains(emptySlot))
                    return;
                emptySlots.Add(emptySlot);
            }
        }

        Invoke("FindCubesToMove", .1f);
        Invoke("UpdateCubesPositions", .2f);
        Invoke("CreateCubeInsideReserveSlots", 1);
    }

    /// <summary>
    /// this function help for instantiate cube in reserve slot after update cube positions
    /// </summary>
    private void CreateCubeInsideReserveSlots()
    {
        GameSetting gameSettings = GameManager.Instance.GetGameSetting();
        for (int i = 0; i < m_reserveSlots.Count; i++)
        {
            SlotComponent slotComponent = m_reserveSlots[i];
            if (!slotComponent.GetIsSlotFull())
            {
                List<CubeComponent> cubeComponents = gameSettings.Cubes;

                int number = Random.Range(gameSettings.MinValue, gameSettings.MaxValue);
                if (number > gameSettings.MaxValue - 5)
                {
                    int numberForRocket = Random.Range(0, 1);
                    if (numberForRocket == 0)
                    {
                        CubeComponent createdCube = Instantiate(gameSettings.RocketSprites[0], m_CubeRoot);
                        createdCube.transform.parent = slotComponent.transform;
                        slotComponent.UpdateSlot(true);
                        createdCube.SetSlotComponent(slotComponent);
                        playerView.GetCreatedCubeComponents().Add(createdCube);
                        createdCube.transform.localPosition = Vector3.zero;
                    }
                    else
                    {
                        CubeComponent createdCube = Instantiate(gameSettings.RocketSprites[1], m_CubeRoot);
                        createdCube.transform.parent = slotComponent.transform;
                        slotComponent.UpdateSlot(true);
                        createdCube.SetSlotComponent(slotComponent);
                        playerView.GetCreatedCubeComponents().Add(createdCube);
                        createdCube.transform.localPosition = Vector3.zero;
                    }
                }
                else
                {
                    CubeComponent createdCube =
                        Instantiate(cubeComponents[Random.Range(0, cubeComponents.Count)], m_CubeRoot);
                    createdCube.transform.parent = slotComponent.transform;
                    slotComponent.UpdateSlot(true);
                    createdCube.SetSlotComponent(slotComponent);
                    playerView.GetCreatedCubeComponents().Add(createdCube);
                    createdCube.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    /// <summary>
    /// This function returen related cubes to move list
    /// </summary>
    /// <returns></returns>
    public List<CubeComponent> GetCubesToMove()
    {
        return cubesToMove;
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