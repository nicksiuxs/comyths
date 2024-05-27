using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifesController : MonoBehaviour
{
    public GameObject text;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = text.GetComponent<TextMeshProUGUI>();
    }

    public void SetLivesCounter(int counter)
    {
        textMeshPro.text = "x " + counter.ToString();
    }

}
