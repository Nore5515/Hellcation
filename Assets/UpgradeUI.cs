using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeUI : MonoBehaviour
{
    public void MovementSpeed () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.MovementSpeed < 75.0f)
        {
            PlayerStats.MovementSpeed += 5.0f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.MovementSpeed);
        }
    }
    public void BulletVelocity () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.BulletVelocity < 2000.0f)
        {
            PlayerStats.BulletVelocity += 200.0f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.BulletVelocity);
        }
    }
    public void FireRate () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.FireRate > 0.5f)
        {
            PlayerStats.FireRate -= 0.1f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.FireRate);
        }
    }
    public void NumberOfBullets () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.NumberOfBullets < 5)
        {
            PlayerStats.NumberOfBullets++;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.NumberOfBullets);
        }
    }
    public void SwingSpeed () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.SwingSpeed > 0.52f)
        {
            PlayerStats.SwingSpeed -= 0.09f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.SwingSpeed);
        }
    }
    public void ChargeLength () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.ChargeLength < 3000.0f)
        {
            PlayerStats.ChargeLength += 200.0f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.ChargeLength);
        }
    }
    public void SwingSize () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStat.SwingSize < 1.8f)
        {
            PlayerStats.SwingSize += 0.16f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.SwingSize);
        }
    }
    public void NextLevel () {
        var level = "Level" + ++PlayerStats.Level;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
