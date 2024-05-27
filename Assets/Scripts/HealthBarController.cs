using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthSlider;

    public void ChangeMaximumLife(int maximumLife)
    {
        healthSlider.maxValue = maximumLife;
    }

    public void ChangeActualLife(int actualLife)
    {
        healthSlider.value = actualLife;
    }

    public void InitializeHealthBar(int initialLife)
    {
        healthSlider = GetComponent<Slider>();
        ChangeMaximumLife(initialLife);
        ChangeActualLife(initialLife);
    }
}
