using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100.0f;
    [SerializeField] private float _minHealth = 0.0f;

    [SerializeField] private UnityEvent _healthChange = new UnityEvent();

    private float _health;

    public float Health => _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeHealing(float healing)
    {
        if (_health + healing > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += healing;
        }

        _healthChange.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (_health - damage < _minHealth)
        {
            _health = _minHealth;
        }
        else
        {
            _health -= damage;
        }

        _healthChange.Invoke();
    }
}
