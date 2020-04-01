using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHouse : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject upgradeMenu;
    public GameObject oldPlayerPrefab;
    public GameObject newPlayerPrefab;

    public TurnSystem turnSystem;

    GameObject player;
    EnterUpgradeHouse enter;

    public int gridWidth = 15;
    public int gridHeight = 15;

    private void Start()
    {
        enter = GameObject.Find("HousePrefab").GetComponentInParent<EnterUpgradeHouse>();
       
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystem>();
    }

    void Update()
    {
        player = enter.player;
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
        int currentWood = player.GetComponent<Player>().woodCount;
        if(currentWood >= 2)    //Number of woods needed for an upgrade
        {
            player.GetComponent<Player>().maxWood++;
            player.GetComponent<Player>().woodCount -= 2;
            Debug.Log("Current capacity: " + player.GetComponent<Player>().maxWood);

        }
        else { Debug.Log("Too little wood to upgrade"); }

    }

    //Function to increase number of actions avaliable
    public void IncreaseNumberOfActions()
    {
        int currentWood = player.GetComponent<Player>().woodCount;
        if (currentWood >= 2)       //Number of woods needed for an upgrade
        {
            player.GetComponent<Player>().maxActions++;
            player.GetComponent<Player>().woodCount -= 2;
            Debug.Log("Current number of actions: " + player.GetComponent<Player>().maxActions);
        }
        else { Debug.Log("Too little wood to upgrade"); }
    }



    //Function to enable fire player prefab to scorch ground
    public void EnableFirePrefab()
    {
        int currentWood = player.GetComponent<Player>().woodCount;
        if (currentWood >= 5)    //Number of woods needed for an upgrade
        {
            player.GetComponent<Player>().woodCount -= 5;
            Vector3 positionOfPrefab = player.transform.position; 

            // Replace old prefab with the upgraded one
            int indexInTurns = turnSystem.playersGroup.FindIndex(turnClass => turnClass.playerGameObject.transform.position.Equals(positionOfPrefab));
            GameObject fire = Instantiate(newPlayerPrefab, positionOfPrefab, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            fire.name = "fire";
            turnSystem.playersGroup[indexInTurns].playerGameObject = fire;
            player.SetActive(false);

        }
        else { Debug.Log("Too little wood to upgrade"); }

    }

    public void Hire()
    {
        int currentWood = player.GetComponent<Player>().woodCount;
        if (currentWood >= 5)    //Number of woods needed for an upgrade
        {
            player.GetComponent<Player>().woodCount -= 5;
            Vector3 positionOfPrefab = player.transform.position; 

            // Replace old prefab with the upgraded one
            GameObject newLum = Instantiate(oldPlayerPrefab, positionOfPrefab, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            TurnClass turnClass = new TurnClass();
            turnClass.playerGameObject = newLum;
            turnSystem.playersGroup.Add(turnClass);
        }
        else { Debug.Log("Too little wood to upgrade"); }

    }
}
