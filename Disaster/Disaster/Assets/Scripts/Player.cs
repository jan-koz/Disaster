using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int maxActions = 20;
    public static int actionsCount = 0;
    public static int maxWood = 5;

    public static int getActions()
    {
        return actionsCount;
    }

    public static void countActions()
    {
        actionsCount++;
    }

    public static int getMaxWood()
    {
        return maxWood;
    }

    public static int avaliableActions()
    {
        return maxActions - actionsCount;
    }
}
