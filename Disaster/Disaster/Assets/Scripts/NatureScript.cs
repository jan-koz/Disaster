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
    private GameObject enemyPrefab;
    Player player;
    private int callsController = 0;
    private int callsController2 = 1;
    bool kurwa;


    private void Start()
    {
        player = FindObjectOfType<Player>();
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();
        kurwa = false;

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
        enemyPrefab = GameObject.Find("Grid/EnemyPrefab(Clone)");
        isTurn = turnClass.isTurn;
        if (isTurn == false)
        {
            //To change number of spawned trees change these values
            callsController = Random.Range(1, TreeObject.tiles.Count - 1);
            callsController2 = 1;
        }
        if (isTurn)
        {
            StartCoroutine("RespawnTrees");
            //Enemy spawns random number of trees (when he exists)
            if (enemyPrefab != null)
            {
                if (callsController > 0)
                {
                    SpawnTrees();
                    callsController--;
                }

            }
            else
            {
                //Spawn one tree every 4 turns
                if (callsController2 > 0 && TurnSystem.turnCounter % 4 == 2)
                {
                    if (TurnSystem.turnCounter > 5)
                    {
                        SpawnTrees2();
                    }
                    TreePositionIndicator();
                }

                else if (callsController2 > 0 && TurnSystem.turnCounter % 4 == 1)
                    SpawnTrees();
                callsController2--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("KURWWWWWWWWWWWWWWWW: " + hexTreePrefab.tag);
        if (other.gameObject.tag == "Player"  && hexTreePrefab.tag == "toRespawnHover")
        {
            Destroy(hexTreePrefab);
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
        if (TreeObject.tiles.Count > 0)
        {
            int currentPosition = Random.Range(0, TreeObject.tiles.Count);
            Vector3 randomTreePosition = TreeObject.tiles[currentPosition].transform.position;
            if (randomTreePosition != player.transform.position)
            {
                randomTreePosition.y = 0.6f;
                Instantiate(hexTreePrefab, randomTreePosition, transform.rotation);
                hexTreePrefab.tag = "toRespawnHover";
                Debug.Log("THISSSS TAG: "+ this.tag);
                TreeObject.tiles[currentPosition].tag = "hover";
                TreeObject.tiles.RemoveAt(currentPosition);
                emptiedHexes.RemoveAt(currentPosition);
            }
        }
    }

    public void TreePositionIndicator()
    {
        if (TreeObject.tiles.Count > 0)
        {
            int currentPosition = Random.Range(0, TreeObject.tiles.Count);
            treePosition = TreeObject.tiles[currentPosition].transform.position;
            glowingHex = emptiedHexes[currentPosition];
            glowingHex.GetComponent<TreeIndicator>().particle.Play();
            TreeObject.tiles.RemoveAt(currentPosition);
            emptiedHexes.RemoveAt(currentPosition);
        }

    }

    public void SpawnTrees2()
    {
        if (treePosition != null && treePosition != player.transform.position)
        {
            Instantiate(hexTreePrefab, (Vector3)treePosition, transform.rotation);
            for (int i = 0; i < TreeObject.tiles.Count; i++)
            {
                Debug.Log("Tell me the truth pls: " + Vector3.Distance(TreeObject.tiles[i].transform.position, hexTreePrefab.transform.position));
                if (Vector3.Distance(TreeObject.tiles[i].transform.position, hexTreePrefab.transform.position) < 3.1)
                {
                    Debug.Log("INDA LOOP MUDAFCKA");
                    TreeObject.tiles[i].tag = "hover";
                    break;
                }
            }
            hexTreePrefab.tag = "toRespawnHover";
            Debug.Log("NEW HEX TAG: " + hexTreePrefab.tag);
            glowingHex.GetComponent<TreeIndicator>().particle.Stop();
            treePosition = null;
        }
    }

    
}
