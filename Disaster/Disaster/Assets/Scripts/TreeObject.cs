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
        if(other.gameObject.tag == "Player" && this.tag == "hover" 
            && WoodCounter.countWood != Player.maxWood && Player.avaliableActions() >=2)
        {
            Debug.Log("jump");
            WoodCounter.countWood += 1;
            Player.actionsCount++; //adding extra action when cutting a tree
            Destroy(tree);
            this.tag = "Untagged";     
        } else { Debug.Log("No jump"); }
    }
}
