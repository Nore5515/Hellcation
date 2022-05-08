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

    public GameObject enemyDeathSound;

    private bool deathCall = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        enemyDeathSound = GameObject.Find("EnemyDeathSound");
    }

    public void StartDying(){
        if (dying == false){
            GetComponent<BoxCollider2D>().enabled = false;
        }
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
            if (enemyDeathSound.GetComponent<AudioSource>().isPlaying == false && deathCall == false)
            {
                enemyDeathSound.GetComponent<AudioSource>().Play();
            }
            deathCall = true;
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