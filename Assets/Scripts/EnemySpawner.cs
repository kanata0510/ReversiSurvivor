using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float frameDistance;
    [SerializeField] private EnemyBehaviour enemyPrefab;
    [SerializeField] private int spawnCount;

    private readonly System.Random _rand = new System.Random();
    private float _xMin;
    private float _yMin;
    private float _xMax;
    private float _yMax;
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        Vector2 leftBottom = camera.ScreenToWorldPoint(Vector3.zero);
        Vector2 rightTop = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _xMin = leftBottom.x - frameDistance;
        _yMin = leftBottom.y - frameDistance;
        _xMax = rightTop.x + frameDistance;
        _yMax = rightTop.y + frameDistance;
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 position;
            switch (_rand.Next(4))
            {
                case 0:
                    position = new Vector2(_xMin, Random.Range(_yMin, _yMax));
                    break;
                case 1:
                    position = new Vector2(Random.Range(_xMin, _xMax), _yMin);
                    break;
                case 2:
                    position = new Vector2(_xMax, Random.Range(_yMin, _yMax));
                    break;
                case 3:
                    position = new Vector2(Random.Range(_xMin, _xMax), _yMax);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            EnemyBehaviour enemyObj = Instantiate(enemyPrefab, (Vector2)playerTransform.position + position, Quaternion.identity);
            enemyObj.targetTransform = playerTransform;
        }
    }
}
