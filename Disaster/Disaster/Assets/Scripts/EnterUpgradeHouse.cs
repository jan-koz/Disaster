﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterUpgradeHouse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You've entered upgrade house");

            GameObject.Find("Canvas").GetComponent<UpgradeHouse>().Pause();
        }
    }
}
