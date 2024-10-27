using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageable : MonoBehaviour
{
    private int _maxHealth;

    public int MaxHealth 
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    private int _health = 3;

    public int Health 
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    private bool _isAlive = true;
    private bool isInvincible = false;
    private float timeSinceHit;
    public float invincibilityTime = 0.25f;

    public bool IsAlive
    { 
        get 
        {
            return _isAlive;
        }
        set 
        {
            _isAlive = value;
            Debug.Log("IsAlive set " + value);
        }
    }
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (isInvincible) 
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible =false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    public void Hit(int damage)
    {
        if (IsAlive && !isInvincible) 
        {
            Health -= damage;
            isInvincible = true;
        }
    }
}
