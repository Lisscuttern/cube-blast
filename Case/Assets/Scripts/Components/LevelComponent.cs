using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private GridComponent m_gridComponent;
    [SerializeField] private UIGoalsPanel m_uiGoalPanel;
    [SerializeField] private UIMovesPanel m_uiMovesPanel;
    [SerializeField] private RectTransform m_canvas;


    #endregion

    /// <summary>
    /// This function return related ui moves panel
    /// </summary>
    /// <returns></returns>
    public UIMovesPanel GetUIMovesPanel()
    {
        return m_uiMovesPanel;
    }
    
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

    /// <summary>
    /// This function return related canvas
    /// </summary>
    /// <returns></returns>
    public RectTransform GetCanvas()
    {
        return m_canvas;
    }
}
