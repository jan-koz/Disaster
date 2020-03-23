using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform hexTreePrefab;
    public Transform playerPrefab;
    public Transform hexHousePrefab;
    public Transform WoodHousePrefab;

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

    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
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
                if (x==0 && y == 0)
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
                    
                   // player.name = "Hexagon" + x + "|" + y;

                }

                // Upgrade house
                if (x == 2 && y == 0) {
                    Transform upgradeHouse = Instantiate(hexHousePrefab) as Transform;
                    upgradeHouse.position = CalcWorldPos(gridPos);
                    upgradeHouse.tag = "hover";
                }

                //Spawn wood house
                if (x == 0 && y ==2)
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
                if(x >2 || y > 2)
                {
                    hex.gameObject.tag = "hover";
                }
            }
        }
    }
}
