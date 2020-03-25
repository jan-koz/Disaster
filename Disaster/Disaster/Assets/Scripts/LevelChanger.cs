using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private GameObject player;
    private GameObject fire;
    private GameObject enemy;


    private Grid grid;
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        fire = GameObject.Find("fire");
        enemy = GameObject.Find("enemy");
        CheckPosition();
    }

    public void CheckPosition()
    {
        if (enemy != null)
        {
            if (player.transform.position.x == enemy.transform.position.x && player.transform.position.z == enemy.transform.position.z)
            {
                SceneManager.LoadScene("Pokemon", LoadSceneMode.Single);
            }
            if (fire != null)
            {
                if (fire.transform.position.x == enemy.transform.position.x && fire.transform.position.z == enemy.transform.position.z)
                    SceneManager.LoadScene("Pokemon", LoadSceneMode.Single);
            }
        }
    }
}
