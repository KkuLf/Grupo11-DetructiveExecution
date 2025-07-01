using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleMenuManager : MonoBehaviour
{
    public string sceneChange = "";

    public void ChangeScene()
    {
        if (Application.isPlaying) // Aseguramos que el cambio de escena solo suceda durante el juego
        {
            SceneManager.LoadScene(sceneChange);
        }
    }

    public void ExitGame()
    {
        if (Application.isPlaying) // Solo funciona cuando el juego está en ejecución
        {
            Application.Quit();
        }
    }
}
