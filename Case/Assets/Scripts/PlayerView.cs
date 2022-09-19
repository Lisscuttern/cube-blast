using UnityEngine;
using System.Collections.Generic;

public class PlayerView : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private List<CubeComponent> m_createdCubeComponents;
    [SerializeField] private List<CubeComponent> m_raycastCubes;
    [SerializeField] private List<CubeComponent> m_rocketTargetCubes;

    #endregion
    

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
}
