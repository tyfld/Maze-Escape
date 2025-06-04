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
        scoreText.text = $"{collected} / {totalSpheres} morbs colllectées";
    }

    void ShowWinMenu()
    {
        winMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
