using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Weight => _weight;

    private int _health;
    private float _speed;
    private float _weight;

    public void Initialize(int health, float speed, float weight)
    {
        _health = health;
        _speed = speed;
        _weight = weight;

        Debug.Log($"ХП: {_health}, скорость: {_speed}, вес: {_weight}");
    }  
    
    public void MoveTo(Vector3 position) => transform.position = position;
}
