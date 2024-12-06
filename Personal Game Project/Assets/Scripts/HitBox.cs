using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip Dmg;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        damageable damageable = collision.GetComponent<damageable>();
        if (damageable != null)
        {
            m_AudioSource.PlayOneShot(Dmg, 0.3f);
            damageable.Hit(1);
        }
    }
}
