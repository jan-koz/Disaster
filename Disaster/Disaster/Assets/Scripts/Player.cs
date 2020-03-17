using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int actions = 5;
    public int capacity = 5;


    public static int getActions()
    {
        return actions;
    }

    public static void subtractActions()
    {
        actions--;
    }
}
