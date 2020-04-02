using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonopolyGuy : MonoBehaviour
{
    public GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(showSprite());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator showSprite()
    {
        yield return new WaitForSeconds(5); //However many seconds you want
        sprite.GetComponent<SpriteRenderer>().enabled = !sprite.GetComponent<SpriteRenderer>().enabled; //This toggles it
        //StartCoroutine(StartBlinking());
    }
}
