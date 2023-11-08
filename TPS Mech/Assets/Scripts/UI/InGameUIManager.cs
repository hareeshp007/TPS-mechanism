using TPShooter.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPShooter.UI
{
    public class InGameUIManager : MonoBehaviour
    {
        public GameObject MainMenuUI;
        public GameObject InGameUI;
        
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
            Cursor.lockState = CursorLockMode.Locked;
            MainMenuUI.SetActive(false);
        }
        public void Pause()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            MainMenuUI.SetActive(true);
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

