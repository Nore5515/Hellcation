using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public GameObject bullet;
    public AudioSource gunshot;

    public Animator animation;
    public bool canFire = true;
    public float spread = 10;
    public float burstSpeed = 0.05f;

    public int maxHP = 3;
    public int HP = 3;
    public HealthBar hpbar;

    public int iFrames = 0;
    public int maxIFrames = 30;


    void Start ()
    {
        playerBody = GetComponent<Rigidbody2D>();
        iFrames = maxIFrames;
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

        if (iFrames > 0){
            iFrames -= 1;
        }

        //playerBody.velocity = new Vector2(horizontal * PlayerStats.MovementSpeed, vertical * PlayerStats.MovementSpeed);
        Vector2 move = new Vector2(horizontal * PlayerStats.MovementSpeed, vertical * PlayerStats.MovementSpeed);
        playerBody.AddForce(move);
    }

    public void TakeDamage()
    {
        if (iFrames == 0){  
            HP -= 1;
            hpbar.SetHealth(HP);
            iFrames = maxIFrames;
            if (HP <= 0){
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
        
    }

    private IEnumerator Fire()
    {
        canFire = false;
        
        StartCoroutine(Bullets());

        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / PlayerStats.FireRate;
            yield return null;
        }

        canFire = true;
    }

    private IEnumerator Bullets()
    {
        for (int i = 0; i < PlayerStats.NumberOfBullets; i++)
        {
            gunshot.PlayOneShot(gunshot.clip, 0.24f);
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
        instBulletRB.AddForce(direction * PlayerStats.BulletVelocity);
        instBullet.transform.rotation = this.transform.GetChild(2).transform.rotation;

        Destroy(instBullet, 3f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (col.gameObject.GetComponent<Enemy>().dying == false){
                TakeDamage();
            }
        }
    }
}