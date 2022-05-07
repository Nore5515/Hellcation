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
        Debug.Log("Uh oh im starting to dieee");
        dying = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dying);
        if (dying == false)
        {
            // Debug.Log("NOT DEAD");
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
        // Debug.Log("DYING");
        if (dyingCountdown > 0)
        {   
            dyingCountdown -= 1;
            // animation.SetTrigger()
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
        // rb.velocity = (direction * Time.deltaTime * -speed);
        Vector2 newVelo = (direction * Time.deltaTime * -speed);
        rb.velocity += newVelo;
    }

}