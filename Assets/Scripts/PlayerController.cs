using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;
    public GameObject bullet;
    public AudioSource gunshot;
    public float bulletSpeed = 10.0f;
    public float rof = 1.0f; //rate of fire
    public bool canfire = true;
    public Animator animation;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetButtonDown("Fire2") && canfire)
        {
            StartCoroutine(Fire());
        }

        ChangeDirection();
    }


    void ChangeDirection()
    {
        if (horizontal > 0){
            Debug.Log("Right");
            animation.Play("Right");
        }
        else if (horizontal < 0){
            Debug.Log("Left");
            animation.Play("Left");
        }
        else if (vertical > 0){
            Debug.Log("Up");
            animation.Play("Up");
        }
        else if (vertical < 0){
            Debug.Log("Down");
            animation.Play("Down");
        } 
        else{
            Debug.Log("Idle");
            animation.Play("Idle");
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private IEnumerator Fire()
    {
        canfire = false;

        gunshot.Play();
        GameObject instBullet = Instantiate(bullet, this.transform.GetChild(2).GetChild(1).transform.position, Quaternion.identity);
        Rigidbody2D instBulletRB = instBullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (this.transform.GetChild(2).GetChild(1).transform.position - this.transform.position);
        direction.Normalize();
 
        instBulletRB.AddForce(direction * bulletSpeed);
        instBullet.transform.rotation = this.transform.GetChild(2).transform.rotation;

        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / rof;
            yield return null;
        }

        Destroy(instBullet, 3f);
        canfire = true;
    }
}