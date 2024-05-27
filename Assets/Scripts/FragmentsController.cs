using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FragmentsController : MonoBehaviour
{
    public GameObject text;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = text.GetComponent<TextMeshProUGUI>();
    }

    public void SetFragmentCounter(int counter)
    {
        textMeshPro.text = "x " + counter.ToString();
    }
}
