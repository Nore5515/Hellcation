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
    bool swordVisible = false;

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
        if (Input.GetButtonDown("Fire1"))
        {
            swordVisible = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            swordVisible = false;
        }
    }
}