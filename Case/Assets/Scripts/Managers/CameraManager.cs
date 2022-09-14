using UnityEngine;

namespace PEAK
{
    public class CameraManager : Singleton<CameraManager>
    {
        #region SerializeFields

        [SerializeField] private Camera m_camera;

        #endregion
       

        /// <summary>
        /// This function return related camera
        /// </summary>
        /// <returns></returns>
        public Camera GetCamera()
        {
            return m_camera;
        }

        
    }
}