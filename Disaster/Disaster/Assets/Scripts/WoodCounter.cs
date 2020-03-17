using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    private TextMeshProUGUI textMeshW;
    public static int countWood;
    void Start()
    {
        textMeshW = FindObjectOfType<TextMeshProUGUI>();
        countWood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshW.text = countWood.ToString();
    }
}
