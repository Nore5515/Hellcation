using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 50.0f;
    public GameObject bullet;
    public AudioSource gunshot;
    public float bulletSpeed = 10.0f;
    public float rof = 1.0f; //rate of fire

    public Animator animation;
    public bool canFire = true;
    public int bcount = 1;
    public float spread = 10;
    public float burstSpeed = 0.05f;


    void Start ()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (Input.GetButtonDown("Fire2") && canFire)
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

        //playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        Vector2 move = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        playerBody.AddForce(move);
    }

    private IEnumerator Fire()
    {
        canFire = false;
        
        StartCoroutine(Bullets());

        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / rof;
            yield return null;
        }

        canFire = true;
    }

    private IEnumerator Bullets()
    {
        for (int i = 0; i < bcount; i++)
        {
            gunshot.Play();
            NewBullet();
            float normalizedTime2 = 0;
            while(normalizedTime2 <= 1f)
            {
                normalizedTime2 += Time.deltaTime / burstSpeed;
                yield return null;
            }
        }
    }

    void NewBullet()
    {
        GameObject instBullet = Instantiate(bullet, this.transform.GetChild(2).GetChild(1).transform.position, Quaternion.identity);
        Rigidbody2D instBulletRB = instBullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (this.transform.GetChild(2).GetChild(1).transform.position - this.transform.position);
        
        direction.Normalize();
        instBulletRB.AddForce(direction * bulletSpeed);
        instBullet.transform.rotation = this.transform.GetChild(2).transform.rotation;

        Destroy(instBullet, 3f);
    }
}