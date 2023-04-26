using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void LoadPause()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
