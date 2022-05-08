using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    List<Enemy> hitList = new List<Enemy>();

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!hitList.Contains(col.GetComponent<Enemy>())){
                Debug.Log("Collision!");
                Destroy(this.gameObject);
                col.GetComponent<Enemy>().StartDying();
                hitList.Add(col.GetComponent<Enemy>());
            }
        }
    }
}
