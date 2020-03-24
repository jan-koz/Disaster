using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    public bool selected = false;
    public GameObject Player;
    
    void Start()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
    }
    
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.FindWithTag("Player") || GameObject.FindWithTag("PlayerFire"))
            {
                selected = !selected;

                if (selected == true)
                {
                    Player.GetComponent<PlayerMovement>().enabled = true;
                }
                else
                {
                    Player.GetComponent<PlayerMovement>().enabled = false;
                }
            }
        }
    }
}
