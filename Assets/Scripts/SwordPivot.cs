using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPivot : MonoBehaviour
{
    Vector3 mouse_pos;
    Transform target;  //Assign to the object you want to rotate
    Vector3 object_pos;
    float angle;
    public GameObject swordSlash;
    public AudioSource swordSwish;
    bool swordVisible = false;
    public bool canSwing = true;

    float slashX = -0.08254997f;
    float slashY = 0.08254997f;
    float slashZ = 0.3302f;

    public GameObject swordCollider;
    private List<Collider2D> enemies;

    void Start()
    {
        target = this.transform;
    }

    void faceMouse()
    {
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        swordSlash.SetActive(swordVisible);
        if (Input.GetButtonDown("Fire1") && canSwing == true)
        {
            canSwing = false;
            swordCollider.transform.localScale = new Vector3(PlayerStats.SwingSize, PlayerStats.SwingSize, PlayerStats.SwingSize);
            swordSlash.transform.localScale = new Vector3(slashX * PlayerStats.SwingSize, slashY * PlayerStats.SwingSize, slashZ * PlayerStats.SwingSize);
            swordSlash.GetComponent<SpriteRenderer>().flipY = !swordSlash.GetComponent<SpriteRenderer>().flipY;

            enemies = swordCollider.GetComponent<SwordCollider>().GetEnemies();
            int index = 0;
            while (index < enemies.Count){
                if (enemies[index] != null)
                {
                    enemies[index].GetComponent<Enemy>().StartDying();
                }
                index += 1;
            }
            
            Vector2 direction = (this.transform.GetChild(1).position - this.transform.position);
            direction.Normalize();
            //Debug.Log(direction);
            this.transform.parent.GetComponent<PlayerController>().playerBody.AddForce(direction * PlayerStats.ChargeLength);
            this.transform.parent.GetComponent<PlayerController>().iFrames = this.transform.parent.GetComponent<PlayerController>().maxIFrames; 
            this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = true;

            StartCoroutine(SeeSword());
            StartCoroutine(SwordDelay());
            StartCoroutine(ChargeBoxActive());
        }
    }

    private IEnumerator SeeSword()
    {
        swordVisible = true;
        swordSwish.Play();
        float duration = 0.1f;
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        swordVisible = false;
    }

    private IEnumerator ChargeBoxActive()
    {
        float duration = 0.25f;
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = false;
    }

    private IEnumerator SwordDelay()
    {
        float normalizedTime = 0;
            while(normalizedTime <= 1f)
            {
                normalizedTime += Time.deltaTime / PlayerStats.SwingSpeed;
                yield return null;
            }
        canSwing = true;
    }
}

     
 
 