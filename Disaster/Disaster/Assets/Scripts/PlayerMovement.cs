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

    private void Start()
    {
        newPosition = transform.position;
        gridMeasures = FindObjectOfType<Grid>();
        Debug.Log(gridMeasures.hexWidth);
        Debug.Log(gridMeasures.hexHeight);
    }

    private void Update()
    {
        if(Player.avaliableActions() > 0)
        {
            Move();
        }
        else
        {
            
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

                    if (newX <= gridMeasures.hexWidth + 0.1f && newZ <= gridMeasures.hexHeight + 0.1f )
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
