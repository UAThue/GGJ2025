using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
        //Hacky as heck
        if (sceneName == "MainScene")
        {
            GameManager.instance.SetVolume(0);
        }
    }
}
