using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damageable {

    public override void Hit(float amount)
    {
        GameOverManager.Instance.Lives--;
    }
}
