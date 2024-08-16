using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public int Health => health;
    [SerializeField] private int health;
    public int Attack => attack;
    [SerializeField] private int attack;
    public Sprite Sprite => sprite;
    [SerializeField] private Sprite sprite;
}
