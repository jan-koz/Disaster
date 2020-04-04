﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeObject : MonoBehaviour
{
    public GameObject tree;
    public GameObject scorched;
    private Vector3 position;
    public static int countDestroedTrees;
    public static float currentFireHexAmount = 0; // tutaj trzeba będzie zliczyć ile jest serio prefabów na scenie ale na razie napiszę jakąś liczbe
    private GameObject nature;
    public static List<GameObject> tiles = new List<GameObject>();
    [HideInInspector]
    public DamageBar damage;
    public GameObject test;
    private void Start()
    {
        //player = FindObjectOfType<Player>();
        countDestroedTrees = 0;
        nature = GameObject.Find("Nature");
        damage = FindObjectOfType<DamageBar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (other.gameObject.tag == "Player" && this.tag == "hover"
            && player.woodCount != player.maxWood && player.avaliableActions() >= 1)
        {
            Debug.Log("jump");
            player.woodCount += 1;
            player.actionsCount++; 
            position = tree.transform.position;
            nature.GetComponent<NatureScript>().addPositionToList(position);
            nature.GetComponent<NatureScript>().addToEmptiedHexes(this.gameObject);

            Destroy(tree);
            countDestroedTrees++;
            this.tag = "Untagged";
            tiles.Add(this.gameObject);
        }

        //checking if prefab of player changed and if so changing the ground to scorched
        else if (other.gameObject.tag == "PlayerFire" && this.tag == "hover"
            && player.woodCount != player.maxWood && player.avaliableActions() >= 2)
        {
            player.woodCount += 1;
            player.actionsCount++;
            Vector3 positionOfThis = tree.transform.parent.position;
            Destroy(tree.transform.parent.gameObject);
            Instantiate(scorched, positionOfThis, tree.transform.rotation * Quaternion.Euler(0f, -90f, 0f));
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
