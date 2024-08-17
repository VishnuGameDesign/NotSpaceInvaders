using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //unity events
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
