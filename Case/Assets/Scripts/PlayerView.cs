using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private List<CubeComponent> m_createdCubeComponents;
    
    [SerializeField] private List<CubeComponent> m_raycastCubes;


    
    
    /// <summary>
    /// This function return related created cube components
    /// </summary>
    /// <returns></returns>
    public List<CubeComponent> GetRaycastCubes()
    {
        return m_raycastCubes;
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
