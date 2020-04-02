using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float smoothSpeed = 0.125f;
    public Transform playerPrefab;
    public Vector3 offset;
    TurnSystem turnSystem;
    public Vector2 cameraLimit;
    private Vector3 testPlayerPosition;

    private void Start()
    {
        turnSystem = GameObject.FindObjectOfType<TurnSystem>();
    }


    void Update()
    {
        // current position of our camera
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.z += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.z -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }

        //scrolling?

        pos.x = Mathf.Clamp(pos.x, -cameraLimit.x, cameraLimit.x);
        pos.z = Mathf.Clamp(pos.z, -cameraLimit.y, cameraLimit.y);

        transform.position = pos;
    }

    public void FindPlayer()
    {
        testPlayerPosition = turnSystem.playersGroup.Find(turnClass => turnClass.isTurn).playerGameObject.transform.position;
        Vector3 desiredPosition = new Vector3(testPlayerPosition.x, testPlayerPosition.y, testPlayerPosition.z) + offset;

        transform.position = desiredPosition;

    }
}
