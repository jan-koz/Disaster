using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureScript : MonoBehaviour
{
    public Transform hexTreePrefab;
    private List<Vector3> listOfPosition = new List<Vector3>();
    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;
    private bool once = false;

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

        if(once == false)
        {
            //SpawnTrees();
            //once = true;
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
    public void addPositionToList(Vector3 position)
    {
        listOfPosition.Add(position);
        
    }

    public List<Vector3> getListOfPosition()
    {
        return listOfPosition;
    }
    public void SpawnTrees()
    {
        if (listOfPosition.Count > 0) 
        {
            Vector3 randomTreePosition = listOfPosition[0];
            Instantiate(hexTreePrefab, randomTreePosition, transform.rotation);
            listOfPosition.RemoveAt(0);
            
        }

    }
}
