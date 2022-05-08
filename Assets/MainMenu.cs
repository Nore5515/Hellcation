using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject attributions;

    public void Begin()
    {
        PlayerStats.MovementSpeed = 50.0f;
        PlayerStats.BulletVelocity = 1000.0f;
        PlayerStats.FireRate = 1.0f;
        PlayerStats.NumberOfBullets = 1;
        PlayerStats.SwingSpeed = 1.0f;
        PlayerStats.ChargeLength = 2000.0f;
        PlayerStats.SwingSize = 1.0f;
        PlayerStats.Level = 1;
        PlayerStats.TotalTime = 0.0f;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    
    public void ToggleAttributions(){
        attributions.SetActive(!attributions.activeSelf);
    }
}
