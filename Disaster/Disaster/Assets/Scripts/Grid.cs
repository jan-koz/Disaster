using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public GameObject image;
    public GameObject image2;
    public GameObject image3;
    private bool check = true;
    private bool check2 = true;

    public Transform hexTreePrefab;
    public Transform playerPrefab;
    public Transform enemyPrefab;
    public Transform hexHousePrefab;
    public Transform WoodHousePrefab;
    private bool hasSpawned = false;

    public int gridWidth = 15;
    public int gridHeight = 15;

    [HideInInspector]
    public float hexWidth = 0.8f;
    [HideInInspector]
    public float hexHeight = 1.0f;
    public float gap = 0.0f;

    Vector3 startPos;

    void Start()
    {
        AddGap();
        CalcStartPos();
        CreateGrid();
    }

    private void Awake()
    {
        StartCoroutine(WaitForInstruction(image));
    }
    void Update()
    {
        
        if (TreeObject.countDestroedTrees > Enemy.maxCollectedWoodEnt && !hasSpawned)
        {
            CreateEnemy();
            TreeObject.countDestroedTrees = 0;
            if (check2)
            {
                image2.SetActive(true);
                StartCoroutine(WaitForInstruction(image3));
            }

        }

        if (check)
        {
            if (Player.maxWood == WoodCounter.countWood)
            {
                image2.SetActive(true);
                StartCoroutine(WaitForInstruction(image2));
            }
        }
    }

    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }

    public Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }

    public void SpawnRandomTree()
    {

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (x == 2 && y == 2)
                {
                    Transform hexTree = Instantiate(hexTreePrefab) as Transform;
                    Vector2 gridPos = new Vector2(x, y);
                    hexTree.position = CalcWorldPos(gridPos);
                    hexTree.parent = this.transform;
                }
            }
        }
    }

    void CreateEnemy()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Vector2 gridPos = new Vector2(x, y);

                if (x == 1 && y == 0)
                {
                    Transform enemy = Instantiate(enemyPrefab) as Transform;
                    hasSpawned = true;
                    enemy.position = CalcWorldPos(gridPos);
                    Vector3 pos = transform.position;
                    Vector3 pos2 = transform.position;
                    pos.y = 1.5f;
                    transform.position = pos;
                    enemy.parent = this.transform;
                    transform.position = pos2;
                    enemy.name = "enemy";
                }
            }
        }

    }
    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(hexTreePrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;
                if (x == 0 && y == 0)
                {
                    Transform player = Instantiate(playerPrefab) as Transform;
                    //Vector2 playerPos = new Vector2(x, y + 1.0f);                
                    player.position = CalcWorldPos(gridPos);
                    Vector3 pos = transform.position;
                    Vector3 pos2 = transform.position;
                    pos.y = 1.5f;
                    transform.position = pos;
                    player.parent = this.transform;
                    transform.position = pos2;
                    player.name = "player";

                    // player.name = "Hexagon" + x + "|" + y;

                }

                // Upgrade house
                if (x == 2 && y == 0)
                {
                    Transform upgradeHouse = Instantiate(hexHousePrefab) as Transform;
                    upgradeHouse.position = CalcWorldPos(gridPos);
                    upgradeHouse.tag = "hover";
                }

                //Spawn wood house
                if (x == 0 && y == 2)
                {
                    Transform woodHouse = Instantiate(WoodHousePrefab) as Transform;
                    woodHouse.position = CalcWorldPos(gridPos);
                    woodHouse.tag = "hover";

                }
                if (x <= 2 && y <= 2)
                {
                    // hex.GetComponentInChildren<BoxCollider>.
                    hex.transform.GetChild(2).gameObject.SetActive(false);
                }
                if (x > 2 || y > 2)
                {
                    hex.gameObject.tag = "hover";
                }
            }
        }
    }

    public IEnumerator WaitForInstruction(GameObject image)
    {
        yield return new WaitForSeconds(10f);
        image.SetActive(false);
    }
}
