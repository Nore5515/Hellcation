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
        if (Input.GetButtonDown("Fire1") && swordVisible == false)
        {
            enemies = swordCollider.GetComponent<SwordCollider>().GetEnemies();
            int index = 0;
            while (index < enemies.Count){
                enemies[index].GetComponent<Enemy>().StartDying();
                index += 1;
            }
            Debug.Log("CLICKED");
            swordSlash.GetComponent<SpriteRenderer>().flipY = !swordSlash.GetComponent<SpriteRenderer>().flipY;
            swordVisible = true;
            StartCoroutine(Countdown());
            swordSwish.Play();
        }
    }

    private IEnumerator Countdown()
    {
        float duration = 0.1f; // 3 seconds you can change this 
        //to whatever you want
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        
        Debug.Log("Swapping");
        swordVisible = false;
    }
}

     
 
 