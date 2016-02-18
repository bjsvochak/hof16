using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public void Shoot(Transform trans)
    {
        GameObject projectile = (GameObject)Instantiate(Resources.Load("Projectile"), trans.position + trans.forward * 5, trans.rotation) as GameObject;
    }
}
