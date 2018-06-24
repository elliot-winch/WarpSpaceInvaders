using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Shoot
{

    public KeyCode shootKey = KeyCode.Space;
    public float coolDown = 0.1f;

    bool canShoot = true;

    void Update()
    {

        if (Input.GetKeyDown(shootKey) && canShoot)
        {
            StartCoroutine(CoolDown());

            base.LaunchProjectile();

        }
    }

    IEnumerator CoolDown()
    {
        canShoot = false;

        yield return new WaitForSeconds(coolDown);

        canShoot = true;
    }
}
