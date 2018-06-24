using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [HideInInspector]
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Damageable>() != null)
        {
            collision.collider.GetComponent<Damageable>().Hit(damage);
        }

        Destroy(gameObject);
    }
}
