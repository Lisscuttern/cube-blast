using UnityEngine;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColorType m_EcolorType;

    #endregion


    /// <summary>
    /// This function help for select cube with click
    /// </summary>
    public void Select()
    {
        Debug.Log(this.gameObject.name);
    }
    
    /// <summary>
    /// This function returen related e color type
    /// </summary>
    /// <returns></returns>
    public EColorType GetEColorType()
    {
        return m_EcolorType;
    }
}
