using DG.Tweening;
using UnityEngine;

namespace PEAK
{
    public static class CommonTypes 
    {
        //TAGS
        public static string CUBE_TAG = "Cube";
        public static string SLOT_TAG = "Slot";

        //DATA KEYS
        public static string LEVEL_ID_DATA_KEY = "level_data";
        
    }
    
    public static class GameUtils
    {
        public static void SwitchCanvasGroup(CanvasGroup a, CanvasGroup b, float duration = 0.25F)
        {
            Sequence sequence = DOTween.Sequence();

            if(a != null)
                sequence.Join(a.DOFade(0, duration));
            if(b != null)
                sequence.Join(b.DOFade(1, duration));

            sequence.OnComplete(() =>
            {
                if(a != null)
                    a.blocksRaycasts = false;
                if(b != null)
                    b.blocksRaycasts = true;
            });

            sequence.Play();
        }

        public static Vector2 WorldToCanvasPosition(RectTransform canvas, Camera camera, Vector3 worldPosition)
        {
            Vector2 tempPosition = camera.WorldToViewportPoint(worldPosition);

            tempPosition.x *= canvas.sizeDelta.x;
            tempPosition.y *= canvas.sizeDelta.y;

            tempPosition.x -= canvas.sizeDelta.x * canvas.pivot.x;
            tempPosition.y -= canvas.sizeDelta.y * canvas.pivot.y;

            return tempPosition;
        }
    }
}
