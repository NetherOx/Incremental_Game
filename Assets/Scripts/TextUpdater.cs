using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    private TMPro.TMP_Text textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TMPro.TMP_Text>();

        textMeshPro.text = "Total: " + ValueController.amount.ToString();
    }

    private void UpdateText(float value)
    {
        textMeshPro.text = "Total: " + value.ToString();
    }

    private void OnEnable()
    {
        ValueController.OnValueChanged += UpdateText;
    }

    private void OnDisable()
    {
        ValueController.OnValueChanged -= UpdateText;
    }
}
