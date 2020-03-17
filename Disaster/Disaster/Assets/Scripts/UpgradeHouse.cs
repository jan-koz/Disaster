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
    }

    public void Pause()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("PlayerPrefab(Clone)").GetComponent<PlayerMovement>().enabled = false;
       
    }

    //Function to increase max ammount of carried wood.
    public void IncreaseWoodCapacity()
    {
        int currentWood = WoodCounter.countWood;
        if(currentWood >= 2)    //Number of woods needed for an upgrade
        {
            Player.maxWood++;
            WoodCounter.countWood -= 2;
            Debug.Log("Current capacity: " + Player.maxWood);

        }
        else { Debug.Log("Too little wood to upgrade"); }

    }

    //Function to increase number of actions avaliable
    public void IncreaseNumberOfActions()
    {
        int currentWood = WoodCounter.countWood;
        if (currentWood >= 2)       //Number of woods needed for an upgrade
        {
            Player.maxActions++;
            WoodCounter.countWood -= 2;
            Debug.Log("Current number of actions: " + Player.maxActions);
        }
        else { Debug.Log("Too little wood to upgrade"); }
    }
        public void Skill3()
    {
        Debug.Log("Skill 3 upgraded");
    }
}
