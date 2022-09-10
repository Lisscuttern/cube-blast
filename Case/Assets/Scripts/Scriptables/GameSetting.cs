using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings", order = 0)]
public class GameSetting : ScriptableObject
{
    [Header("Cubes")] 
    public List<CubeComponent> Cubes;
    public float CubeScaleMultiply;
    public float CubeScaleDuration;
}
