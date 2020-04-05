using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonopolyGuy : MonoBehaviour
{
    public GameObject sprite;
    public GameObject sprite2;
    public GameObject sprite3;
    public GameObject sprite4;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(showSprite());
    }

    IEnumerator showSprite()
    {
        yield return new WaitForSeconds(4); //However many seconds you want
        sprite.SetActive(false);
        sprite2.SetActive(true);
        
        if(sprite2 != null)
        {
            yield return new WaitForSeconds(4); //However many seconds you want
            sprite2.SetActive(false);
            sprite3.SetActive(true);
        }

        if(sprite3 != null)
        {
            yield return new WaitForSeconds(4); //However many seconds you want
            sprite3.SetActive(false);
            sprite4.SetActive(true);
        }

        if (sprite4 != null)
        {
            yield return new WaitForSeconds(4); //However many seconds you want
            sprite4.SetActive(false);
        }

    }
}
