using UnityEngine;

public class SlotComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Vector2 m_cubeCoordinate;
    [SerializeField] private bool m_isSlotEmpty;
    [SerializeField] private CubeComponent m_cubeComponent;

    #endregion
    
    #region Private Fields


    #endregion

    /// <summary>
    /// This function help for control slot is empty or not
    /// </summary>
    /// <param name="offset"></param>
    /// <returns></returns>
    public bool SlotCapacityControl(float offset)
    {
        if (GetCubeCoordinates() == new Vector2(GetCubeCoordinates().x, GetCubeCoordinates().y - offset))
            return true;

        return false;
    }
    
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
        m_isSlotEmpty = value;
    }

    /// <summary>
    /// This funtion return related is slot empty
    /// </summary>
    /// <returns></returns>
    public bool GetIsSlotFull()
    {
        return m_isSlotEmpty;
    }

    /// <summary>
    /// This function return related cube coordinates
    /// </summary>
    /// <returns></returns>
    public Vector2 GetCubeCoordinates()
    {
        return m_cubeCoordinate;
    }


    /// <summary>
    /// This function help for set cube component
    /// </summary>
    /// <param name="cubeComponent"></param>
    public void SetCubeComponent(CubeComponent cubeComponent)
    {
        m_cubeComponent = cubeComponent;
    }

    /// <summary>
    /// This function return related cube component
    /// </summary>
    /// <returns></returns>
    public CubeComponent GetCubeComponent()
    {
        return m_cubeComponent;
    }
}
