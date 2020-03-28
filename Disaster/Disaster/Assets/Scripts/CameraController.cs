using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed;
    //how close we need to get to the endge of the screen to move
    public float cameraMovementBorder;
    public Vector2 cameraLimit;

    // Update is called once per frame
    void Update()
    {
        // current position of our camera
        Vector3 pos = transform.position;
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - cameraMovementBorder)
        {
            pos.z += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= cameraMovementBorder)
        {
            pos.z -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - cameraMovementBorder)
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= cameraMovementBorder)
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }

        //scrolling?

        pos.x = Mathf.Clamp(pos.x, -cameraLimit.x, cameraLimit.x);
        pos.z = Mathf.Clamp(pos.z, -cameraLimit.y, cameraLimit.y);

        transform.position = pos;
    }
}
