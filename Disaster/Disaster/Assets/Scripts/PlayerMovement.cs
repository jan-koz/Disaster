using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerPrefab;
    public Grid gridMeasures;
    Vector3 newPosition;
    Vector3 playerPositon;

    // turn based system
    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn = false;

    private void Start()
    {
        newPosition = transform.position;
        gridMeasures = FindObjectOfType<Grid>();
        Debug.Log(gridMeasures.hexWidth);
        Debug.Log(gridMeasures.hexHeight);

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
            if (Player.avaliableActions() > 0)
            {
                Move();
            }
            else
            {
                isTurn = false;
                turnClass.isTurn = isTurn;
                turnClass.wasTurnPrev = true;
                Player.actionsCount = 0;
            }
        }
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

                    if (newX <= gridMeasures.hexWidth + 0.1f && newZ <= gridMeasures.hexHeight + 0.1f)
                    {
                        Vector3 pos = newPosition;
                        pos.y = 0.5f;
                        transform.position = pos;
                        Player.countActions();
                    }
                }
            }
        }
    }
}
