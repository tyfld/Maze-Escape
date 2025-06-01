using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Charge la scène du jeu
    public void Play()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quitte le jeu
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
