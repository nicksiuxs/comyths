using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FragmentsController : MonoBehaviour
{
    public GameObject text;
    private TextMeshProUGUI textMeshPro;

    public void SetFragmentCounter(int counter)
    {
        textMeshPro = text.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "x " + counter.ToString();
    }
}
