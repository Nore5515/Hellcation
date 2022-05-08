using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    public Animator animation;
    public bool dying = false;
    public int dyingCountdown = 300;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    public void StartDying(){
        dying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying == false)
        {
            Chase();
            if (player.transform.position.y > this.transform.position.y){
                animation.Play("ImpWalkUp");
            }
            else{
                animation.Play("ImpWalk");
            }
        }
        if (dying == true){
            Die();
        }
        
    }

    void Die()
    {
        if (dyingCountdown > 0)
        {   
            dyingCountdown -= 1;
            animation.Play("ImpDeath");
        } 
        else
        {
            Destroy(this.gameObject);
        }
                    
    }


    void Chase()
    {
        Vector3 direction = rb.transform.position - player.transform.position;
        direction.Normalize();
        Vector2 newVelo = (direction * Time.deltaTime * -speed);
        rb.velocity += newVelo;
    }

}