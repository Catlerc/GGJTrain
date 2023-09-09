using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthHolder playerHealth;
    public RectTransform healthBarRect;

    private float defaultWidth;

    void changeHealth(float health)
    {
        healthBarRect.sizeDelta =
            new Vector2(health / playerHealth.maxHealth * defaultWidth, healthBarRect.sizeDelta.y);
    }

    private void Start()
    {
        playerHealth.onHealthChange.AddListener(changeHealth);
        defaultWidth = healthBarRect.sizeDelta.x;
    }
}