using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        damageable damageable = collision.GetComponent<damageable>();
        if (damageable != null)
        {
            damageable.Hit(1);
        }
    }
}
