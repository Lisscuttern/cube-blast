using PEAK;
using TMPro;
using UnityEngine;

public class UIMovesPanel : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private TextMeshProUGUI m_moveText;

    #endregion

    #region Private Fields

    private int moveValue;

    #endregion

    private void Start()
    {
        Level currentLevel = LevelService.GetCurrentLevel();
        moveValue = currentLevel.MoveValue;
        CreateMoveText();
    }
    
    /// <summary>
    /// This function help for create move text
    /// </summary>
    private void CreateMoveText()
    {
        m_moveText.text = $"{moveValue}";
    }

    /// <summary>
    /// This function help for set move value
    /// </summary>
    /// <param name="value"></param>
    public void SetMoveValue(int value = 1)
    {
        moveValue -= value;
        CreateMoveText();
    }
    
    /// <summary>
    /// This function return related move value
    /// </summary>
    /// <returns></returns>
    public int GetMoveValue()
    {
        return moveValue;
    }
}
