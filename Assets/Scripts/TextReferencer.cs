using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TextReferencer : MonoBehaviour
{
    [System.Serializable]
    public struct TextField
    {
        public string key;
        public TMP_Text textComponent;
    }

    [SerializeField] private List<TextField> textFields;

    private Dictionary<string, TMP_Text> fieldLookup;

    private void Awake()
    {
        fieldLookup = new Dictionary<string, TMP_Text>();
        foreach (var field in textFields)
        {
            fieldLookup[field.key] = field.textComponent;
        }
    }

    public void SetText(string key, string text)
    {
        if (fieldLookup.TryGetValue(key, out TMP_Text target))
        {
            target.text = text;
        }
        else
        {
            Debug.LogWarning($"No text field found with key '{key}' on {gameObject.name}");
        }
    }
}
