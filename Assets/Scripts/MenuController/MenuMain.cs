using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuMain : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(1);
    }
}
