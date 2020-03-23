using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHouse : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject upgradeMenu;
    private GameObject oldPlayerPrefab;
    public GameObject newPlayerPrefab;

    public TurnSystem turnSystem;
    public TurnClass turnClass;

    public int gridWidth = 15;
    public int gridHeight = 15;

    private void Start()
    {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();
    }

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

 

    void Resume()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
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



    //Function to enable fire player prefab to scorch ground
    public void EnableFirePrefab()
    {
        int currentWood = WoodCounter.countWood;
        if (currentWood >= 5)    //Number of woods needed for an upgrade
        {
            oldPlayerPrefab = GameObject.Find("PlayerPrefab(Clone)");
            Vector3 positionOfPrefab = oldPlayerPrefab.transform.position;
            Destroy(GameObject.Find("PlayerPrefab(Clone)").gameObject);
            Instantiate(newPlayerPrefab, positionOfPrefab, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            WoodCounter.countWood -= 5;
            turnSystem.playersGroup[1].playerGameObject = newPlayerPrefab;
        }
        else { Debug.Log("Too little wood to upgrade"); }

    }
}
