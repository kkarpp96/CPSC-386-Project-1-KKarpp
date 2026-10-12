using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
