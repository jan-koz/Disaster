using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int maxCollectedWoodEnt = 7; //can be changed even should
    public static int GetMaxWood()
    {
        return maxCollectedWoodEnt;
    }
}
