using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [Space]
    [Tooltip("Check if script is on the Player")]
    [SerializeField] private bool _onPlayer;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        if (_onPlayer)
            _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        if (_onPlayer)
            _fill.color = _gradient.Evaluate(slider.normalizedValue);
    }
}
