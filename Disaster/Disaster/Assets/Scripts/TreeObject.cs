using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeObject : MonoBehaviour
{
    public GameObject tree;
    public GameObject scorched;
    private Vector3 position;
    public static int countDestroedTrees;
    private static int currentFireHexAmount; // tutaj trzeba będzie zliczyć ile jest serio prefabów na scenie ale na razie napiszę jakąś liczbe
    private GameObject nature;
    [HideInInspector]
    public DamageBar damage;

    private void Start()
    {
        //player = FindObjectOfType<Player>();
        countDestroedTrees = 0;
        currentFireHexAmount = 0;
        nature = GameObject.Find("Nature");
        damage = FindObjectOfType<DamageBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (other.gameObject.tag == "Player" && this.tag == "hover"
            && player.woodCount != player.maxWood && player.avaliableActions() >= 2)
        {
            Debug.Log("jump");
            player.woodCount += 1;
            player.actionsCount++; //adding extra action when cutting a tree
            //List that stores position of cut trees
            position = tree.transform.position;
            nature.GetComponent<NatureScript>().addPositionToList(position);
            nature.GetComponent<NatureScript>().addToEmptiedHexes(this.gameObject);

            Destroy(tree);
            countDestroedTrees++;
            this.tag = "Untagged";
        } 

        //checking if prefab of player changed and if so changing the ground to scorched
        else if (other.gameObject.tag == "PlayerFire" && this.tag == "hover"
            && player.woodCount != player.maxWood && player.avaliableActions() >= 2) 
        {
            player.woodCount += 1;
            player.actionsCount++;
            Vector3 positionOfThis = this.transform.position;
            Instantiate(scorched, positionOfThis, transform.rotation * Quaternion.Euler(0f, -180f, 0f));
            Destroy(this.gameObject);
            currentFireHexAmount++;
            damage.SetDamage(currentFireHexAmount);
        } 

        else { Debug.Log("No jump"); }
    }

    public Vector3 getPosition()
    {
        return position;
    }
}
