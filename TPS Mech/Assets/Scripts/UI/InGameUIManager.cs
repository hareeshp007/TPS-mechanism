using TPShooter.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TPShooter.UI
{
    public class InGameUIManager : MonoBehaviour
    {
        public GameObject MainMenuUI;
        public GameObject InGameUI;

        public Joystick PlayerJoystick;
        public Joystick CameraJoystick;
        public Button Jump;
        public Button Interact;

        private void Start()
        {
            PlayerServices.Instance.SetUIManager(this);
#if UNITY_STANDALONE_WIN
            InGameUI.SetActive(false);
#endif
#if UNITY_ANDROID
            InGameUI.SetActive(true);
#endif

            MainMenuUI.SetActive(false);
        }
        public void Resume()
        {
            Time.timeScale = 1;
#if UNITY_STANDALONE_WIN
            Cursor.lockState = CursorLockMode.Locked;
#endif
#if UNITY_ANDROID
            Cursor.lockState = CursorLockMode.None;
#endif
            MainMenuUI.SetActive(false);
#if UNITY_ANDROID
            InGameUI.SetActive(true);
#endif
        }
        public void Pause()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            MainMenuUI.SetActive(true);
#if UNITY_ANDROID
            InGameUI.SetActive(false);
#endif
        }
        public void Exit()
        {
            Application.Quit();
        }
        public void Restart()
        {
            UnityEngine.SceneManagement.Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.buildIndex);
        }

    }
}

