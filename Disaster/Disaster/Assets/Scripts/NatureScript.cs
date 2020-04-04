using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureScript : MonoBehaviour
{
    public Transform hexTreePrefab;
    private List<Vector3> listOfPosition = new List<Vector3>();
    private List<GameObject> emptiedHexes = new List<GameObject>();
    System.Nullable<Vector3> treePosition;
    GameObject glowingHex;

    TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;
    private bool once = false;
    public GameObject enemyPrefab;
    Player player;
    private int callsController = 0;
    private int callsController2 = 1;
    


    private void Start()
    {
        player = FindObjectOfType<Player>();
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
        enemyPrefab = GameObject.Find("enemy");
        isTurn = turnClass.isTurn;
        if(isTurn == false)
        {
            //To change number of spawned trees change these values
            callsController = Random.Range(1, listOfPosition.Count - 1);
            callsController2 = 1;
        }
        if(isTurn)
        {
            //Enemy spawns random number of trees (when he exists)
            if (enemyPrefab != null)
            {
                if (callsController > 0)
                {
                    SpawnTrees();
                    callsController--;
                }
                
            }
            //Spawn one tree every 4 turns
            if (callsController2 > 0 && TurnSystem.turnCounter % 4 == 2)
            {
                if (TurnSystem.turnCounter > 5)
                {
                    SpawnTrees2();
                }
                TreePositionIndicator();
                callsController2--;
            }
            StartCoroutine("RespawnTrees");
        }

    }

    public IEnumerator RespawnTrees()
    {
        yield return new WaitForSeconds(1f);
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
    }
    public void addPositionToList(Vector3 position)
    {
        listOfPosition.Add(position);
        
    }
    public void addToEmptiedHexes(GameObject element)
    {
        emptiedHexes.Add(element);

    }

    public List<Vector3> getListOfPosition()
    {
        return listOfPosition;
    }

    //Spawning trees at random positions
    public void SpawnTrees()
    {
        if (listOfPosition.Count > 0) 
        {
            int currentPosition = Random.Range(0, listOfPosition.Count);
            Vector3 randomTreePosition = listOfPosition[currentPosition];
            if(randomTreePosition.x != player.transform.position.x && randomTreePosition.z != player.transform.position.z)
            {
                Transform treeTrans = Instantiate(hexTreePrefab, randomTreePosition, transform.rotation);
                treeTrans.parent = emptiedHexes[currentPosition].transform;
                hexTreePrefab.tag = "hover";
                listOfPosition.RemoveAt(currentPosition);
                emptiedHexes.RemoveAt(currentPosition);
            }            
        }
    }

    public void TreePositionIndicator()
    {
        if (listOfPosition.Count > 0)
        {
            int currentPosition = Random.Range(0, listOfPosition.Count);
            treePosition = listOfPosition[currentPosition];
            glowingHex = emptiedHexes[currentPosition];
            glowingHex.GetComponent<TreeIndicator>().particle.Play();
            listOfPosition.RemoveAt(currentPosition);
            emptiedHexes.RemoveAt(currentPosition);
        }

    }

    public void SpawnTrees2()
    {
        if (treePosition != null)
        {
            glowingHex.GetComponent<TreeIndicator>().particle.Stop();
            Vector3 treePos = (Vector3)treePosition;
            if (treePos.x != player.transform.position.x && treePos.z != player.transform.position.z)
            {
                Transform treeTrans = Instantiate(hexTreePrefab, treePos, transform.rotation);
                treeTrans.parent = glowingHex.transform;
                hexTreePrefab.tag = "hover";
                treePosition = null;
            }
        }
    }
}
