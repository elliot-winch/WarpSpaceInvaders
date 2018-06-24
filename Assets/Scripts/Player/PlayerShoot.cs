using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public KeyCode shootKey = KeyCode.Space;
    public float coolDown = 0.1f;
    public float damage = 10f;
    public float projectileSpeed;
    public GameObject projectile;

    bool canShoot = true;

    void Update()
    {

        if (Input.GetKeyDown(shootKey) && canShoot)
        {
            StartCoroutine(CoolDown());

            GameObject projectileObj = Instantiate(projectile, transform.position, transform.rotation);

            //Make sure the projectile doesn't collider with the player when it's launched
            foreach(Collider2D c in GetComponentsInChildren<Collider2D>())
            {
                foreach (Collider2D d in projectileObj.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(c, d);
                }
            }

            //Set damage of projectile
            projectileObj.GetComponent<Projectile>().damage = this.damage;

            //Set projectile's velocity
            projectileObj.GetComponent<Rigidbody2D>().velocity = projectileObj.transform.up * projectileSpeed;

        }
    }

    IEnumerator CoolDown()
    {
        canShoot = false;

        yield return new WaitForSeconds(coolDown);

        canShoot = true;
    }
}
