using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly float lookRadius = 5f;
    private Player player;
    private Grid gridMeasures;
    private Vector3 newPosition;
    private Vector3 playerPositon;

    void Start()
    {
        player = FindObjectOfType<Player>();
        gridMeasures = FindObjectOfType<Grid>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= lookRadius)
        {
            //tu będzie atak !
            MoveEnemy(transform.position, player.transform.position); ///COS TU NIE GRA
            FaceTarget(transform.position, player.transform.position);
        }
    }

    private void MoveEnemy(Vector3 enemyPosition, Vector3 playerPosition)
    {
        newPosition = playerPositon;
        float newX = Mathf.Abs(playerPosition.x - enemyPosition.x);
        float newZ = Mathf.Abs(playerPosition.z - enemyPosition.z);
        if (newX <= gridMeasures.hexWidth + 0.1f && newZ <= gridMeasures.hexHeight + 0.1f)
        {
            Vector3 pos = newPosition;
            pos.y = 0.5f;
            enemyPosition = pos;
        }
    }

    void FaceTarget(Vector3 enemyPosition, Vector3 playerPosition)
    {
        //direction to the target
        Vector3 direction = (playerPosition - enemyPosition).normalized;
        //get the rotation to point to that target
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //update our own roatation to point in this direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }

    //display it in editor 
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
