using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoodHouse : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject woodStorageMenu;
    private static int storedWood = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
        }
        
    }

    //Resume game
    void Resume()
    {
        woodStorageMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pause when entering wood house
    public void Pause()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        woodStorageMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void storeWood()
    {
        int currentWood = WoodCounter.countWood;
        if (currentWood > 0)
        {
            storedWood++;
            WoodCounter.countWood--;
            Debug.Log("You've stored piece of wood. Wood in storage: " + storedWood);
        } else
        {
            Debug.Log("You don't have any wood.");
        }


        
    }

    public void withdrawWood()
    {
        if (storedWood > 0)
        {
            storedWood--;
            WoodCounter.countWood++;
            Debug.Log("You've withdrawn piece of wood");
        } else
        {
            Debug.Log("Not enough wood in storage.");
        }
        
    }

    public static int getStoredWood()
    {
        return storedWood;
    }
}
