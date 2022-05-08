using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeUI : MonoBehaviour
{
    public void MovementSpeed () {
        PlayerStats.MovementSpeed += 10.0f;
        Debug.Log(PlayerStats.MovementSpeed);
    }
    public void BulletVelocity () {
        PlayerStats.BulletVelocity += 200.0f;
        Debug.Log(PlayerStats.BulletVelocity);
    }
    public void FireRate () {
        PlayerStats.FireRate -= 0.1f;
        Debug.Log(PlayerStats.FireRate);
    }
    public void NumberOfBullets () {
        PlayerStats.NumberOfBullets++;
        Debug.Log(PlayerStats.NumberOfBullets);
    }
    public void SwingSpeed () {
        PlayerStats.SwingSpeed -= 0.09f;
        Debug.Log(PlayerStats.SwingSpeed);
    }
    public void ChargeLength () {
        PlayerStats.ChargeLength += 200.0f;
        Debug.Log(PlayerStats.ChargeLength);
    }
    public void SwingSize () {
        PlayerStats.SwingSize += 0.16f;
        Debug.Log(PlayerStats.SwingSize);
    }
    public void NextLevel () {
        var level = "Level" + PlayerStats.Level++;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
