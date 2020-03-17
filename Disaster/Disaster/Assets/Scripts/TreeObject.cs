using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeObject : MonoBehaviour
{
    public GameObject tree;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && this.tag == "hover" && WoodCounter.countWood != player.maxWood)
        {
            Debug.Log("jump");
            WoodCounter.countWood += 1;
            Destroy(tree);
            this.tag = "Untagged";     
        }
    }
}
