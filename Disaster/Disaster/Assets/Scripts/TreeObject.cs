using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObject : MonoBehaviour
{
    public GameObject tree;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("jump");
            Destroy(tree);
            this.tag = "Untagged";
        }
    }
}
