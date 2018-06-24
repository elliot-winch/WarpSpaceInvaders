using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable {

    public float damageOnPlayerHit = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //On collsiion with the player, cause the player some damage and be destroyed
        if (collision.collider.GetComponent<PlayerHealth>() != null)
        {
            collision.collider.GetComponent<PlayerHealth>().Hit(damageOnPlayerHit);

            base.Destroyed();

        }
    }
}
