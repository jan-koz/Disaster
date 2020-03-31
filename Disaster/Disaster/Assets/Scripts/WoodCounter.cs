using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshW;
    public TurnSystem turnSystem;

    private void Update()
    {
        if (!turnSystem.playersGroup[0].isTurn)
        {
            Player player = turnSystem.playersGroup.Find(turnClass => turnClass.isTurn).playerGameObject.GetComponent<Player>();
            textMeshW.text = "Wood: " + player.woodCount.ToString() + "/" + player.maxWood;
        }
    }
}
