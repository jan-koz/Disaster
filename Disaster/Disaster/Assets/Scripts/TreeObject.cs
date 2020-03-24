using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeObject : MonoBehaviour
{
    public GameObject tree;
    public GameObject scorched;
    Player player;
    private Vector3 position; 
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.tag == "hover"
            && WoodCounter.countWood != Player.maxWood && Player.avaliableActions() >= 2)
        {
            Debug.Log("jump");
            WoodCounter.countWood += 1;
            Player.actionsCount++; //adding extra action when cutting a tree
            //List that stores position of cut trees
            position = tree.transform.position;
            GameObject.Find("Nature").GetComponent<NatureScript>().addPositionToList(position);
            Destroy(tree);
            this.tag = "Untagged";
            Debug.Log("dlugosc listy: " + GameObject.Find("Nature").GetComponent<NatureScript>().getListOfPosition().Count);
        } 

        //checking if prefab of player changed and if so changing the ground to scorched
        else if (other.gameObject.tag == "PlayerFire" && this.tag == "hover"
            && WoodCounter.countWood != Player.maxWood && Player.avaliableActions() >= 2) 
        {
            WoodCounter.countWood += 1;
            Player.actionsCount++;
            Vector3 positionOfThis = this.transform.position;
            Instantiate(scorched, positionOfThis, transform.rotation * Quaternion.Euler(0f, -180f, 0f));
            Destroy(this.gameObject);
        } 

        else { Debug.Log("No jump"); }
    }

    public Vector3 getPosition()
    {
        return position;
    }
}
