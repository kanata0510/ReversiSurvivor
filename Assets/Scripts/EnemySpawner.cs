using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Rect range;
    [SerializeField] private EnemyBehaviour enemyPrefab;
    [SerializeField] private int spawnCount;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float xpos = Random.Range(range.xMin, range.xMax);
            float ypos = Random.Range(range.yMin, range.yMax);
            Instantiate(enemyPrefab, new Vector3(xpos, ypos), Quaternion.identity);
        }
    }
}
