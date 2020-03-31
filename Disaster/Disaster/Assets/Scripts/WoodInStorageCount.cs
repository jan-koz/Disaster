using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WoodInStorageCount : MonoBehaviour
{
    public Text text; 
    void Update()
    {
        text.text = "Wood stored: " + WoodHouse.getStoredWood().ToString();
    }
}
