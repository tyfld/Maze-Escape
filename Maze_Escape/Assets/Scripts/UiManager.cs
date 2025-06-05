using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField]
    private int totalSpheres = 6;
    private int collected = 0;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private GameObject pauseMenu;
    private bool isPaused = false;

    private void Awake() 
    {
        Instance = this;
        CollectibleMorb.OnSphereCollected += HandleSphereCollected;
    }

    private void  OnDestroy()
    {
        CollectibleMorb.OnSphereCollected -= HandleSphereCollected;
    }

    private void Start()
    {
        UpdateUI();
        winMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    void HandleSphereCollected()
    {
        collected++;
        UpdateUI();

        if (collected >= totalSpheres)
        {
            ShowWinMenu();
        }
    }

    void UpdateUI()
    {
        scoreText.text = $"{collected} / {totalSpheres} morbs collected";
    }

    void ShowWinMenu()
    {
        winMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
