using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetHealth(int health){
        if (health == 1){
            this.gameObject.GetComponent<Image>().sprite = health1;
        }
        if (health == 2){
            this.gameObject.GetComponent<Image>().sprite = health2;
        }
        if (health == 3){
            this.gameObject.GetComponent<Image>().sprite = health3;
        }
        if (health == 0){
            this.gameObject.GetComponent<Image>().sprite = health0;
        }
    }
}
