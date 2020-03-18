using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureScript : MonoBehaviour
{
    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;

    private void Start()
    {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();

        foreach (TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name)
            {
                turnClass = tc;
            }
        }
    }

    private void Update()
    {
        isTurn = turnClass.isTurn;

        if(isTurn)
        {
            StartCoroutine("RespawnTrees");
        }
    }

    IEnumerator RespawnTrees()
    {
        yield return new WaitForSeconds(1f);

        // ADD respawn trees
        

        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
    }
}
