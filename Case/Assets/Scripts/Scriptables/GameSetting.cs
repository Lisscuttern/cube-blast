using UnityEngine;
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

        
        public int MinGoalValue;
        public int MaxGoalValue;

        [Header("Rockets")]
        public List<CubeComponent>  RocketSprites;

        [Header("Duck")]
        public CubeComponent Duck;
        
        [Header("Balloon")]
        public CubeComponent Balloon;
        public int BalloonMinValue;
        public int BalloonMaxValue;


        [Header("Rect Transform")]
        public RectTransform RedSRectTransform;
        public RectTransform BlueRectTransform;
        public RectTransform YellowRectTransform;
        public RectTransform GreenRectTransform;
        public RectTransform PurpleRectTransform;
        
        public RectTransform BaseRectTransform;


        [Header("Sprites")]
        public Sprite RedSprite;
        public Sprite BlueSprite;
        public Sprite YellowSprite;
        public Sprite GreenSprite;
        public Sprite PurpleSprite;
        
        public Sprite BaseSprite;
        
        [Header("Random Values")]
        public int MinValue;
        public int MaxValue;





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
        
        /// <summary>
        /// This function help for change sprite with color type
        /// </summary>
        /// <param name="eColorType"></param>
        /// <param name="sprite"></param>
        public RectTransform ChangeRectTransform(EColorType eColorType)
        {
            switch (eColorType)
            {
                case EColorType.RED:
                    return RedSRectTransform;
                    break;
                case EColorType.BLUE:
                    return BlueRectTransform;
                    break;
                case EColorType.YELLOW:
                    return YellowRectTransform;
                    break;
                case EColorType.GREEN:
                    return GreenRectTransform;
                    break;
                case EColorType.PURPLE:
                    return PurpleRectTransform;
                    break;
            }

            return BaseRectTransform;
        }
    }
}

