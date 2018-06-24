using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable {

    public ParticleSystem onDestroyedParticleSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //On collsiion with the player, cause the player some damage and be destroyed
        if (collision.collider.GetComponent<PlayerHealth>() != null)
        {
            collision.collider.GetComponent<PlayerHealth>().Hit(0f); //the amount of damage doesnt matter, the player always just loses a life

            Destroyed();
        }
    }

    public override void Destroyed()
    {
        ScoreTracker.Instance.IncrementScore();

        StartCoroutine(DestroyedAnimation());
    }

    private IEnumerator DestroyedAnimation()
    {

        gameObject.SetActive(false);

        if(onDestroyedParticleSystem != null)
        {
            GameObject psObj = Instantiate(onDestroyedParticleSystem.gameObject, transform.position, transform.rotation);

            psObj.GetComponent<ParticleSystem>().Play();

            //Wait for particle system to finish
            yield return new WaitForSeconds(psObj.GetComponent<ParticleSystem>().main.duration);

            Destroy(psObj);
        }

        base.Destroyed();
    }
}
