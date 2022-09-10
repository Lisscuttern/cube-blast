using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private GridComponent m_gridComponent;

    #endregion


    /// <summary>
    /// This function returen related grid component
    /// </summary>
    /// <returns></returns>
    public GridComponent GetGridComponent()
    {
        return m_gridComponent;
    }
}
