using UnityEngine;
using UnityEngine.UI;

public class ButtonIncrementer : MonoBehaviour
{
    public static float incrementValue = 1f;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ValueController.IncreaseValue(incrementValue);
    }
}
