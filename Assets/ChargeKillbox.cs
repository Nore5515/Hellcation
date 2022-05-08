using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeKillbox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().StartDying();
        }
    }
}
