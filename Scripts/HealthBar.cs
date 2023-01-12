using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _animationSpeed;

    private Slider _healthbar;
    private Coroutine _healbarAnimation;

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
        if(_healbarAnimation != null)
        StopCoroutine(_healbarAnimation);

         _healbarAnimation = StartCoroutine(HealthbarAnimation(health / maxHealth));
    }

    private IEnumerator HealthbarAnimation(float targetValue)
    {
        while(_healthbar.value != targetValue)
        {
            _healthbar.value = Mathf.Clamp(targetValue, _healthbar.minValue, _healthbar.maxValue);

            yield return null;
        }
    }
}
