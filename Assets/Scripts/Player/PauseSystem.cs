using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private static bool isPaused = false;

    public void Resume()
    {
        panel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    private void Pause()
    {
        panel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
