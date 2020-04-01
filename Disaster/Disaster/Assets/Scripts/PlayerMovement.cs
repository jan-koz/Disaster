using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerPrefab;
    public float hexWidth = 0.8f;
    public float hexHeight = 1.0f;
    Vector3 newPosition;
    string hitTag;
    Vector3 playerPositon;

    // turn based system
    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;

    Player player;

    public GameObject active;

    private void Start()
    {
        player = this.GetComponentInParent<Player>();
        newPosition = transform.position;
        active.SetActive(false);
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();

        foreach (TurnClass tc in turnSystem.playersGroup)
        {
            turnClass = tc;
        }
    }

    private void Update()
    {
        isTurn = turnClass.isTurn;
        if (isTurn)
        {            
            if (player.avaliableActions() > 0) //&& (getClickedTile() != "hover" && player.GetWoodCount() != player.getMaxWood()))
            {
                active.SetActive(true);
                if ((getClickedTile() == "hover" && player.GetWoodCount() == player.getMaxWood()) /*|| (getClickedTile() == "hover" && player.getActions() == 1)*/)
                {
                    Debug.Log("Nie powinno Cie tu byc");
                }
                else
                {
                    Move();
                    Debug.Log("You've jumped on: " + getClickedTile());
                }
            }
            else
            {
                isTurn = false;
                active.SetActive(false);
                turnClass.isTurn = isTurn;
                turnClass.wasTurnPrev = true;
                player.actionsCount = 0;
            }
        }

    }
    private string getClickedTile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                hitTag = hit.collider.gameObject.tag;
            }
        }
        return hitTag;
    }

    private void Move()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                playerPositon = new Vector3(playerPrefab.transform.position.x, playerPrefab.transform.position.y, playerPrefab.transform.position.z);
                if (Physics.Raycast(ray, out hit))
                {
                    newPosition = hit.collider.gameObject.transform.position;
                    
                    float newX = Mathf.Abs(newPosition.x - playerPositon.x);
                    float newZ = Mathf.Abs(newPosition.z - playerPositon.z);
                    Debug.Log(newX);
                    Debug.Log(newZ);
                    
                    if (newX <= hexWidth + 2.1f && newZ <= hexHeight + 2.1f && newPosition != playerPositon)
                    {
                           // Debug.Log("Hit tag: " + hitTag);
                        Vector3 pos = newPosition;
                        pos.y = 0.5f;
                        if(pos != transform.position)
                        {
                            transform.position = pos;
                            player.countActions();
                        }
                    }
                }
            }
        }
    }
    }
