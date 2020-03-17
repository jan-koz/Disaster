using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshW;
    public static int countWood;
    void Start()
    {
        countWood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshW.text = "Wood: " + countWood.ToString() + "/" + Player.maxWood;
    }
}
