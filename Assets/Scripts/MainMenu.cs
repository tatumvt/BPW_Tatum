using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
