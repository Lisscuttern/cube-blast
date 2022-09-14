using UnityEngine;
using System.Collections.Generic;

public class UIGoalsPanel : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private List<UIGoalItem> m_goalItems;

    #endregion
    

    /// <summary>
    /// This function return related ui goals
    /// </summary>
    /// <returns></returns>
    public List<UIGoalItem> GetUıGoalItems()
    {
        return m_goalItems;
    }
}
