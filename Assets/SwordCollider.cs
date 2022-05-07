using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{

    private List<Collider2D> enemies = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemies.Add(col);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (enemies.Contains(col))
            {
                enemies.Remove(col);
            }
        }
    }

    public List<Collider2D> GetEnemies()
    {
        return enemies;
    }
}