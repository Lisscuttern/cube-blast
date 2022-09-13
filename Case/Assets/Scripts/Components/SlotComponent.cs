using UnityEngine;

public class SlotComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Vector2 m_cubeCoordinate;
    [SerializeField] private bool m_isSlotFull;

    #endregion


    /// <summary>
    /// This function help for set cube coordinates
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetCubeCoordinate(int x, int y)
    {
        m_cubeCoordinate = new Vector2(x, y);
    }
    
    /// <summary>
    /// This function help for control slot is empty or not
    /// </summary>
    public void UpdateSlot(bool value)
    {
        m_isSlotFull = value;
    }

    /// <summary>
    /// This funtion return related is slot empty
    /// </summary>
    /// <returns></returns>
    public bool GetIsSlotFull()
    {
        return m_isSlotFull;
    }

    /// <summary>
    /// This function return related cube coordinates
    /// </summary>
    /// <returns></returns>
    public Vector2 GetCubeCoordinates()
    {
        return m_cubeCoordinate;
    }
}
