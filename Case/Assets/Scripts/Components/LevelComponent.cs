using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private GridComponent m_gridComponent;
    [SerializeField] private UIGoalsPanel m_uiGoalPanel;

    #endregion

    
    /// <summary>
    /// This function returen related goal panel
    /// </summary>
    /// <returns></returns>
    public UIGoalsPanel GetUiGoalPanel()
    {
        return m_uiGoalPanel;
    }

    /// <summary>
    /// This function returen related grid component
    /// </summary>
    /// <returns></returns>
    public GridComponent GetGridComponent()
    {
        return m_gridComponent;
    }
}
