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
    public int bcount = 1;
    public float spread = 10;


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

        for (int i = 0; i < bcount; i++)
        {
            NewBullet();
        }
        
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / rof;
            yield return null;
        }

        canfire = true;
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