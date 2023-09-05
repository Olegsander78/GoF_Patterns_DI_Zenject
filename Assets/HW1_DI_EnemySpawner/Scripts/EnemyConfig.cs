using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName ="EnemiesConfigs/Config")]
public class EnemyConfig: ScriptableObject
{
    [SerializeField] private Enemy _prefab;
    [SerializeField, Range(1, 30)] private int _health;
    [SerializeField, Range(1, 30)] private float _speed;
    [SerializeField, Range(1, 50)] private float _weight;

    public Enemy Prefab => _prefab;
    public int Health => _health;
    public float Speed => _speed;
    public float Weight => _weight;
}
