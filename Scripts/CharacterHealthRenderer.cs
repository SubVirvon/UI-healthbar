using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthRenderer : MonoBehaviour
{
    [SerializeField] private Slider _healbar;
    [SerializeField] private float _animationSpeed;

    private Coroutine _healbarAnimation;
    private float _value;

    public void SetMaxHealth (float maxHealth)
    {
        _healbar.maxValue = maxHealth;
        _healbar.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        _value = health;

        if (_healbarAnimation != null)
            StopCoroutine(_healbarAnimation);

        _healbarAnimation = StartCoroutine(HealthbarAnimation());
    }

    private IEnumerator HealthbarAnimation()
    {
        while(_healbar.value != _value)
        {
            _healbar.value = Mathf.MoveTowards(_healbar.value, _value, _animationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
