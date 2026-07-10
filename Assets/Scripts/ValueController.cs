using UnityEngine;
using System;

public class ValueController : MonoBehaviour
{
    public static float amount = 0f;
    public static float increment = 1f;
    public static event Action<float> OnValueChanged;

    public static void IncreaseValue(float value)
    {
        amount += value;
        OnValueChanged?.Invoke(amount);
    }

    public static void DecreaseValue(float value)
    {
        amount -= value;
        OnValueChanged?.Invoke(amount);
    }
}
