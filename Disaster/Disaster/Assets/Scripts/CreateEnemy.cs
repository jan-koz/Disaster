using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public bool hasSpawned = false;
    public Transform enemyPrefab;
    // Start is called before the first frame update

    void Update()
    {
        if (TreeObject.countDestroedTrees > Enemy.maxCollectedWoodEnt && !hasSpawned)
        {
            CreateEnemyEnemy();
            TreeObject.countDestroedTrees = 0;
        }
    }
    
    public void CreateEnemyEnemy()
    {
        Transform enemy = Instantiate(enemyPrefab) as Transform;
        hasSpawned = true;
        enemy.position = this.transform.position;
        Vector3 pos = transform.position;
        Vector3 pos2 = transform.position;
        pos.y = -0.5f;
        transform.position = pos;
        enemy.parent = this.transform;
        transform.position = pos2;
        enemy.name = "enemy";
    }
}
