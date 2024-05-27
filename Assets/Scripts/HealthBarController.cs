using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthSlider;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

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
        ChangeMaximumLife(initialLife);
        ChangeActualLife(initialLife);
    }
}
