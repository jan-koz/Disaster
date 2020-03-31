using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterWoodHouse : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        
            player = other.transform.gameObject;
            //if(player)
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerFire")
            {
                Debug.Log("You've entered wood house");

                GameObject.Find("Canvas").GetComponent<WoodHouse>().Pause();
            }
        
    }
}
