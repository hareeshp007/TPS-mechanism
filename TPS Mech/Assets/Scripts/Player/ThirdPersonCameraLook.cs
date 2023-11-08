using Cinemachine;
using UnityEngine;

namespace TPShooter.Player
{
    [RequireComponent(typeof(CinemachineFreeLook))]
    public class ThirdPersonCameraLook : MonoBehaviour
    {
        public Joystick CameraJoystick;
        private CinemachineFreeLook cinemachine;
        [SerializeField]
        private float RotaionSpeed = 5f;

        public void setJoystick(Joystick joystick)
        {
            CameraJoystick = joystick;
        }
#if UNITY_ANDROID
        private void Start()
        {
            cinemachine  = GetComponent<CinemachineFreeLook>();
            cinemachine.m_XAxis.m_InputAxisName = "";
            cinemachine.m_YAxis.m_InputAxisName = "";
        }
        private void Update()
        {
            if (CameraJoystick.Horizontal != 0 || CameraJoystick.Vertical != 0)
            {
                CameraRotate();
            }
            
        }

        private void CameraRotate()
        {
            cinemachine.m_XAxis.Value += CameraJoystick.Horizontal * cinemachine.m_XAxis.m_MaxSpeed*Time.deltaTime;
            cinemachine.m_YAxis.Value += CameraJoystick.Vertical  * Time.deltaTime;
        }

#endif
    }
}


