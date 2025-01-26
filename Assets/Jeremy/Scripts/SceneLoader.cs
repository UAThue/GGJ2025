using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string characterScene;
    public string spawnerScene;

    void Start()
    {
        SceneManager.LoadScene(characterScene, LoadSceneMode.Additive);
        SceneManager.LoadScene(spawnerScene, LoadSceneMode.Additive);

        GameManager.instance.StartGame();
    }

}
