using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    public string textKey;
    private TMP_Text textComponent;

    void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    public void UpdateText()
    {
        if (LanguageManager.Instance != null)
        {
            string translation = LanguageManager.Instance.GetText(textKey);
            textComponent.text = translation;
        }
    }

    void Start()
    {
        UpdateText();
    }
}
