using System;
using UnityEngine;

[Serializable]
public class EnemyConfig
{
    [SerializeField] private Enemy _prefab;
    [SerializeField, Range(1, 10)] private int _health;
    [SerializeField, Range(1, 10)] private float _speed;
    [SerializeField, Range(1, 50)] private float _weight;

    public Enemy Prefab => _prefab;
    public int Health => _health;
    public float Speed => _speed;
    public float Weight => _weight;
}
