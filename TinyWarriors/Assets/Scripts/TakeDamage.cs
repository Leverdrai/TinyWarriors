using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private float health;

    public void TakeDamageFromEnemy(float damage)
    {
        health -= damage;
        Debug.Log("healt remaining: " + health);
    }
}
