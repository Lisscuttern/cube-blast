using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace PEAK
{
    [CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSetting : ScriptableObject
    {
        [Header("Cubes")] 
        public List<CubeComponent> Cubes;
        public float CubeScaleMultiply;
        public float CubeScaleDuration;
    
        public Level[] Levels;
        
        public Sprite[] Sprites;


        public int MinGoalValue;
        public int MaxGoalValue;

        public Sprite RedSprite;
        public Sprite BlueSprite;
        public Sprite YellowSprite;
        public Sprite GreenSprite;
        public Sprite PurpleSprite;
        
        public Sprite BaseSprite;




        /// <summary>
        /// This function help for change sprite with color type
        /// </summary>
        /// <param name="eColorType"></param>
        /// <param name="sprite"></param>
        public Sprite ChangeSprite(EColorType eColorType)
        {
            switch (eColorType)
            {
                case EColorType.RED:
                    return RedSprite;
                    break;
                case EColorType.BLUE:
                    return BlueSprite;
                    break;
                case EColorType.YELLOW:
                    return YellowSprite;
                    break;
                case EColorType.GREEN:
                    return GreenSprite;
                    break;
                case EColorType.PURPLE:
                    return PurpleSprite;
                    break;
            }

            return BaseSprite;
        }
    }
}

