using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    public TMP_Dropdown languageDropdown;
    public static LanguageManager Instance;

    // Langue par défaut
    public static string currentLanguage = "EN";
    private Dictionary<string, Dictionary<string, string>> localizedTexts;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        LoadLanguageData();
        LoadSavedLanguage();

        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
    }

    void LoadSavedLanguage()
    {
        string savedLang = PlayerPrefs.GetString("language", "EN");
        currentLanguage = savedLang;

        languageDropdown.value = currentLanguage == "EN" ? 0 : 1;

        UpdateAllLocalizedTexts();
    }

    void LoadLanguageData()
    {
        localizedTexts = new Dictionary<string, Dictionary<string, string>>();

        // Anglais
        localizedTexts["EN"] = new Dictionary<string, string>()
        {
            {"play", "Play"},
            {"options", "Options"},
            {"quit", "Quit"},
            {"back", "Back"},
            {"pause", "Pause"},
            {"resume", "Resume"},
            {"restart", "Restart"},
            {"collected", "Spheres collected"},
            {"win", "Victory!"}
        };

        // Français
        localizedTexts["FR"] = new Dictionary<string, string>()
        {
            {"play", "Démarrer"},
            {"options", "Options"},
            {"quit", "Quitter"},
            {"back", "Retour"},
            {"pause", "Pause"},
            {"resume", "Reprendre"},
            {"restart", "Recommencer"},
            {"collected", "Sphères collectées"},
            {"win", "Victoire !"}
        };
    }

    void OnLanguageChanged(int index)
    {
        currentLanguage = index == 0 ? "EN" : "FR";
        PlayerPrefs.SetString("language", currentLanguage);
        UpdateAllLocalizedTexts();
    }

    public string GetText(string key)
    {
        return localizedTexts[currentLanguage][key];
    }

    public void UpdateAllLocalizedTexts() {
        foreach (LocalizedText lt in FindObjectsOfType<LocalizedText>()) 
        {
            lt.UpdateText();
        }
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        foreach (LocalizedText lt in FindObjectsOfType<LocalizedText>()) 
        {
            lt.UpdateText();
        }
    }
}
