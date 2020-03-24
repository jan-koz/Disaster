using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfLumberjacks : MonoBehaviour
{    
    TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;

    [HideInInspector]
    public List<GameObject> lumberjacks = new List<GameObject>();

    private void Start()
    {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();
        lumberjacks.Add(GameObject.FindGameObjectWithTag("Player"));
        foreach (TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name)
            {
                turnClass = tc;
            }
        }
    }
}
