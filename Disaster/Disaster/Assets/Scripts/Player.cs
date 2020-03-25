using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxActions = 10;
    public int actionsCount = 0;
    public int maxWood = 5;
    public int woodCount = 0;
    
    public int getActions()
    {
        return actionsCount;
    }

    public void countActions()
    {
        actionsCount++;
    }

    public int getMaxWood()
    {
        return maxWood;
    }

    public int avaliableActions()
    {
        return maxActions - actionsCount;
    }

    public void UseAllActions()
    {
        actionsCount = maxActions;
    }

    public int GetWoodCount()
    {
        return woodCount;
    }   
}
