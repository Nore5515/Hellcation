using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public void MovementSpeed () {
        PlayerStats.MovementSpeed += 10.0f;
        Debug.Log(PlayerStats.MovementSpeed);
    }
    public void BulletVelocity () {
        PlayerStats.BulletVelocity += 200.0f;
    }
    public void FireRate () {
        PlayerStats.FireRate -= 0.1f;
    }
    public void NumberOfBullets () {
        PlayerStats.NumberOfBullets++;
    }
    public void SwingSpeed () {
        PlayerStats.SwingSpeed -= 0.09f;
    }
    public void ChargeLength () {
        PlayerStats.ChargeLength += 200.0f;
    }
    public void SwingSize () {
        PlayerStats.SwingSize += 0.16f;
    }
    public void NextLevel () {
        
    }
}
