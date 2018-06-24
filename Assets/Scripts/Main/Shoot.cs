using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float damage = 10f;
    public float projectileSpeed;
    public bool shootUpOrDown = true; // if true, will shoot up
    public GameObject projectile;

    public string layerName;
    public Color color;

    protected GameObject LaunchProjectile()
    {
        GameObject projectileObj = Instantiate(projectile, transform.position, transform.rotation);

        //Set damage of projectile
        projectileObj.GetComponent<Projectile>().damage = this.damage;

        //Set projectile's velocity
        projectileObj.GetComponent<Rigidbody2D>().velocity = (shootUpOrDown ? 1 : -1) * projectileObj.transform.up * projectileSpeed;

        //Set color
        projectileObj.GetComponent<SpriteRenderer>().color = color;

        //Set layer
        projectileObj.layer = LayerMask.NameToLayer(layerName);

        return projectileObj;
    }
}
