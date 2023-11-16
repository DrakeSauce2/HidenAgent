using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] HealthComponet healthComponet;
    PlayerValueGauge valueGauge;

    private void Start()
    {
        GameObject playerGameObject = GameplayStatics.GetPlayerGameObject();
        healthComponet = playerGameObject.GetComponent<HealthComponet>();

        valueGauge = GetComponent<PlayerValueGauge>();
        healthComponet.onHealthChanged += UpdateValue;
        valueGauge.SetValue(healthComponet.GetHealth(), healthComponet.GetMaxHealth());
    }

    private void UpdateValue(float currentHealth, float delta, float maxHealth)
    {
        valueGauge.SetValue(currentHealth, maxHealth);
    }
}
