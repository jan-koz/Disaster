using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionsCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshW;
    public static int countActions;
    void Start()
    {
        countActions = Player.avaliableActions();
    }

    // Update is called once per frame
    void Update()
    {
        countActions = Player.avaliableActions();
        textMeshW.text = "Actions: " + countActions.ToString() + "/" + Player.maxActions;
    }
}
