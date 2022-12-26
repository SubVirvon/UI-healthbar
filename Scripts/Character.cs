using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterHealthRenderer))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private CharacterHealthRenderer _healthRenderer;
    private float _health;

    private void Awake()
    {
        _healthRenderer = GetComponent<CharacterHealthRenderer>();
        _health = _maxHealth;
        _healthRenderer.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health < 0)
            _health = 0;

        _healthRenderer.SetHealth(_health);
    }

    public void TakeHeal(float heal)
    {
        _health += heal;

        if (_health > _maxHealth)
            _health = _maxHealth;

        _healthRenderer.SetHealth(_health);
    }
}
