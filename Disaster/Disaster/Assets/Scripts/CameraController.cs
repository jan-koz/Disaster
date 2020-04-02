using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    public float smoothSpeed = 0.125f;
    public Transform playerPrefab;
    public Vector3 offset;
    Player target;
    //how close we need to get to the endge of the screen to move
    public Vector2 cameraLimit;

    private void Start()
    {
        target = GameObject.FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        // current position of our camera
        Vector3 pos = transform.position;
        if(Input.GetKey("w"))
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
        Vector3  desiredPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z) + offset;
        //Vector3 smoothPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed*Time.deltaTime);

        transform.position = desiredPosition;

    }
}
