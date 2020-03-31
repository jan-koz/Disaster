using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //playerPrefab.transform.position
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            playerPositon = new Vector3(playerPrefab.transform.position.x, playerPrefab.transform.position.y,playerPositon.z);
            if(Physics.Raycast(ray,out hit))
            {
                newPosition = hit.collider.gameObject.transform.position;
                Debug.Log(newPosition.x);
                Debug.Log(newPosition.z);
                float newX = Mathf.Abs(newPosition.x - playerPositon.x);
                float newZ = Mathf.Abs(newPosition.z - playerPositon.z);

                //Debug.Log(newX);
                //Debug.Log(newZ);

                if(newX <= gridMeasures.hexWidth || newZ <= gridMeasures.hexHeight)
                {

                    Vector3 pos = newPosition;
                    pos.y = 0.5f;
                    transform.position = pos;
                }
            }
        }
    }
}
