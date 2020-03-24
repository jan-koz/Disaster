using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    TurnSystem turnSystem;
    public Button endTurnButton;

    private void Start()
    {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();
    }

    void Update()
    {
        if(turnSystem.playersGroup[0].isTurn == true)
        {
            endTurnButton.interactable = false;
        }
        else
        {
            endTurnButton.interactable = true;
        }
    }
}
