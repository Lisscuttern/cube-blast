using PEAK;
using UnityEngine;
using System.Collections.Generic;

public class PlayerView : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private List<CubeComponent> m_createdCubeComponents;
    [SerializeField] private List<CubeComponent> m_raycastCubes;
    [SerializeField] private List<CubeComponent> m_rocketTargetCubes;

    #endregion

    #region Private Fields

    private bool isCanPlay = true;
    private int levelCompleteTarget;

    #endregion

    private void Update()
    {
        LevelComponent levelComponent = GameManager.Instance.GetLevelComponent();

        if (GetLevelCompleteTarget() == 2)
        {
            InterfaceManager.Instance.GetUIWinPanel().WinGame();
        }
        if (m_raycastCubes.Count > 0)
        {
            isCanPlay = false;
        }
        else
        {
            isCanPlay = true;
        }
        
        

        for (int i = 0; i < levelComponent.GetUiGoalPanel().GetUıGoalItems().Count; i++)
        {
            UIGoalItem uiGoalItem = levelComponent.GetUiGoalPanel().GetUıGoalItems()[i];

            if (uiGoalItem.GetGoalIsCompleted())
                return;
            if (uiGoalItem.GetGoalValue() == 0)
            {
                EarnLevelCompleteTarget();
                uiGoalItem.SetGoalIsCompleted(true);
            }

            
        }

        
    }

    /// <summary>
    /// this function help for set is can play
    /// </summary>
    /// <param name="value"></param>
    public void SetIsCanPlay(bool value)
    {
        isCanPlay = value;
    }
    
    /// <summary>
    /// This function return related level complete target
    /// </summary>
    /// <returns></returns>
    public void EarnLevelCompleteTarget(int value = 1)
    {
        levelCompleteTarget += value;
    }

    /// <summary>
    /// This function return related created cube components
    /// </summary>
    /// <returns></returns>
    public List<CubeComponent> GetRaycastCubes()
    {
        return m_raycastCubes;
    }
    
    /// <summary>
    /// This function return related crocket target components
    /// </summary>
    /// <returns></returns>
    public List<CubeComponent> GetRocketTargetCubes()
    {
        return m_rocketTargetCubes;
    }
    
    /// <summary>
    /// This function return related created cube components
    /// </summary>
    /// <returns></returns>
    public List<CubeComponent> GetCreatedCubeComponents()
    {
        return m_createdCubeComponents;
    }

    /// <summary>
    /// This function return related is can play
    /// </summary>
    /// <returns></returns>
    public bool GetIsCanPlay()
    {
        return isCanPlay;
    }

    /// <summary>
    /// This function return related level complete target
    /// </summary>
    /// <returns></returns>
    public int GetLevelCompleteTarget()
    {
        return levelCompleteTarget;
    }
}
