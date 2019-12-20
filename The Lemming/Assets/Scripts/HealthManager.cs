using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int maxHealth;
    public Animator anim;
    public TextMeshProUGUI tmp;

    private int currentHealth;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

        currentHealth = maxHealth;
        tmp.text = currentHealth.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(0);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            currentHealth = 0;
            Death();
        }

        tmp.text = currentHealth.ToString();
        anim.SetTrigger("Shake");
    }

    private void Death()
    {
        
    }
}
