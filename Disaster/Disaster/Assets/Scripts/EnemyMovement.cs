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
    public bool isTurn = false;
    public TurnClass turnClass;
    public TurnSystem turnSystem;
    private NatureScript nature;
    //private int callsController = Random.Range(0,GameObject.Find("Nature").GetComponent<NatureScript>().getListOfPosition().Count);
    private int callsController = 5;
    
    


    void Start()
    {
        player = FindObjectOfType<Player>();
        gridMeasures = FindObjectOfType<Grid>();
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();
        nature = FindObjectOfType<NatureScript>();

        //foreach (TurnClass tc in turnSystem.playersGroup)
        //{
        //    turnClass = tc;
        //}

    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= lookRadius)
        {
            //tu będzie atak !
            FaceTarget(transform.position, player.transform.position);
        }

        isTurn = turnClass.isTurn;
        if (isTurn)
        {
            StartCoroutine(nature.RespawnTrees());
            

            //Probably not needed
            //if(callsController > 0)
            //{
            //    nature.SpawnTrees();
            //    callsController--;
            //}
        }
        else
        {
            isTurn = false;
            turnClass.isTurn = isTurn;
            turnClass.wasTurnPrev = true;
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
