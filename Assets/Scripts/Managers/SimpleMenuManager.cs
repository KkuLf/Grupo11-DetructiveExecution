using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMenuManager : MonoBehaviour
{
    public string sceneChange = "";
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneChange);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
