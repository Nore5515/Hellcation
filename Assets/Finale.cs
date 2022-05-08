using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Finale : MonoBehaviour
{

    public Text totalTime;

    // Start is called before the first frame update
    void Start()
    {   
        totalTime.text = "Your time is: " + PlayerStats.TotalTime.ToString();
    }

    public void Reload(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
