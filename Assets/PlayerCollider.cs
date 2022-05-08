using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    public PlayerController pc;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (col.gameObject.GetComponent<Enemy>().dying == false){
                Debug.Log("Hello!");
                pc.TakeDamage();
            }
        }
    }
}
