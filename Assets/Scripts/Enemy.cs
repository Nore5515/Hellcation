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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
        if (player.transform.position.y > this.transform.position.y){
            animation.Play("ImpWalkUp");
        }
        else{
            animation.Play("ImpWalk");
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