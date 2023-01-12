using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Slider _healthbar;

    private void Awake()
    {
        _healthbar = GetComponent<Slider>();
        _healthbar.value = 1;
    }

    private void OnEnable()
    {
        _character.HealthChanged += OnValueChanget;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= OnValueChanget;
    }

    private void OnValueChanget(float health, float maxHealth)
    {
        _healthbar.value = Mathf.Clamp(health / maxHealth, _healthbar.minValue, _healthbar.maxValue);
    }
}
