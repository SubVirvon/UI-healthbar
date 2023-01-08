using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;

    public event UnityAction<float, float> HealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            _health = 0;
        else
            HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeHeal(float heal)
    {
        _health += heal;

        if (_health > _maxHealth)
            _health = _maxHealth;
        else
            HealthChanged?.Invoke(_health, _maxHealth);
    }
}
