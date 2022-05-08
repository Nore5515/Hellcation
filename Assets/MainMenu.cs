using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Begin()
    {
        PlayerStats.MovementSpeed = 50.0f;
        PlayerStats.BulletVelocity = 1000.0f;
        PlayerStats.FireRate = 1.0f;
        PlayerStats.NumberOfBullets = 1;
        PlayerStats.SwingSpeed = 1.0f;
        PlayerStats.ChargeLength = 2000.0f;
        PlayerStats.SwingSize = 1.0f;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
