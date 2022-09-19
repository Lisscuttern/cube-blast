using PEAK;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIGoalItem : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private TextMeshProUGUI m_goalValueText;
    [SerializeField] private Image m_texture;
    [SerializeField] private int m_goalValue;
    [SerializeField] private EColorType m_eColorType;
    [SerializeField] private RectTransform m_slot;

    #endregion

    #region Private Fields

    private GameSetting gameSetting => GameManager.Instance.GetGameSetting();
    private bool goalIsCompleted = false;

    #endregion

    private void Start()
    {
        CreateGoal();
    }

    /// <summary>
    /// This function help for create goal
    /// </summary>
    private void CreateGoal()
    {
        m_texture.sprite =gameSetting.ChangeSprite(m_eColorType);
        m_goalValue = Random.Range(gameSetting.MinGoalValue, gameSetting.MaxGoalValue);
        m_goalValueText.text = ""+m_goalValue;

    }

    /// <summary>
    /// This function help for set goal is completed
    /// </summary>
    /// <param name="value"></param>
    public void SetGoalIsCompleted(bool value)
    {
        goalIsCompleted = value;
    }

    /// <summary>
    /// This function help for update goal text
    /// </summary>
    /// <param name="value"></param>
    public void UpdateGoalValue(int value = 1)
    {
        m_goalValue -= value;
        m_goalValueText.text = ""+m_goalValue;
    }

    /// <summary>
    /// This function return related goal value
    /// </summary>
    /// <returns></returns>
    public int GetGoalValue()
    {
        return m_goalValue;
    }

    /// <summary>
    /// This function return related e color type
    /// </summary>
    /// <returns></returns>
    public EColorType GetEColor()
    {
        return m_eColorType;
    }

    /// <summary>
    /// This function return related slot
    /// </summary>
    /// <returns></returns>
    public RectTransform GetSlot()
    {
        return m_slot;
    }

    /// <summary>
    /// This function return related goal is completed
    /// </summary>
    /// <returns></returns>
    public bool GetGoalIsCompleted()
    {
        return goalIsCompleted;
    }
}
