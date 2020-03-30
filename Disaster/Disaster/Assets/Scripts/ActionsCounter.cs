using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionsCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshW;
    public TurnSystem turnSystem;

    private void Update()
    {
        if(!turnSystem.playersGroup[0].isTurn)
        {
            //Debug.Log("Ma ture: " + turnSystem.playersGroup.Find(turnClass => turnClass.isTurn).playerGameObject.ToString());
            Player player = turnSystem.playersGroup.Find(turnClass => turnClass.isTurn).playerGameObject.GetComponent<Player>();
            textMeshW.text = "Actions: " + player.avaliableActions().ToString() + "/" + player.maxActions;
        }
    }
}
