using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot {

    public float minTimeBetweenShots = 2f;
    public float maxTimeBetweenShots = 5f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenShots, maxTimeBetweenShots));

            GameObject proj = base.LaunchProjectile();

        }
    }
}
