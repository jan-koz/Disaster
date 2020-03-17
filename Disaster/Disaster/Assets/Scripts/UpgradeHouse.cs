using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHouse : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject upgradeMenu;


    public int gridWidth = 15;
    public int gridHeight = 15;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } 
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Pause();
    //    }
    //}

    void Resume()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        GameObject.Find("PlayerPrefab(Clone)").GetComponent<PlayerMovement>().enabled = true;
        Debug.Log("TimeScale = " + Time.timeScale);
    }

    public void Pause()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        //for (int y = 0; y < gridHeight; y++)
        //{
        //    for (int x = 0; x < gridWidth; x++)
        //    {
        //        GameObject.Find("Hexagon" + x + "|" + y).GetComponent<MouseInteraction>().enabled = false;
        //    }
        //}
        //GameObject.Find("EventSystem").GetComponent<MouseInteraction>().enabled = false;
        //GameObject.Find("Grid").GetComponent<Grid>().enabled = false;
        //GameObject.Find("HousePrefab(Clone)").GetComponent<MouseInteraction>().enabled = false;
        GameObject.Find("PlayerPrefab(Clone)").GetComponent<PlayerMovement>().enabled = false;
        Debug.Log("TimeScale = " + Time.timeScale);
       
    }

    public void Skill1()
    {
        Debug.Log("Skill 1 upgraded");
    }

    public void Skill2()
    {
        Debug.Log("Skill 2 upgraded");
    }

    public void Skill3()
    {
        Debug.Log("Skill 3 upgraded");
    }
}
