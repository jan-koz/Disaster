﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWoodHouse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You've entered wood house");

            GameObject.Find("Canvas").GetComponent<WoodHouse>().Pause();
        }
    }
}
