using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform targetTransform;
    [SerializeField] private EnemyData enemyData;

    private Transform m_Transform;
    // Start is called before the first frame update
    void Start()
    {
        m_Transform = transform;
    }

    private void Update()
    {
        m_Transform.position = Vector2.MoveTowards(m_Transform.position, targetTransform.position, enemyData.Speed);
    }
}
