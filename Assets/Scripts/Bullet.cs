using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
