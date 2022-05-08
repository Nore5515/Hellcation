using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeUI : MonoBehaviour
{
    
    public Button movementSpeed;
    public Button bulletVelocity;
    public Button fireRate;
    public Button numberOfBullets;
    public Button swingSpeed;
    public Button chargeLength;
    public Button swingSize;

    public Text coinsLeft;

    void Update(){
        coinsLeft.text = PlayerStats.UpgradeCoins.ToString();
    }

    public void MovementSpeed () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.MovementSpeed < 75.0f)
        {
            PlayerStats.MovementSpeed += 5.0f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.MovementSpeed);
            if (PlayerStats.MovementSpeed >= 75.0f)
            {
                movementSpeed.interactable = false;
            }
        }
    }
    public void BulletVelocity () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.BulletVelocity < 2000.0f)
        {
            PlayerStats.BulletVelocity += 200.0f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.BulletVelocity);
            if (PlayerStats.BulletVelocity >= 2000.0f)
            {
                bulletVelocity.interactable = false;
            }
        }
    }
    public void FireRate () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.FireRate > 0.5f)
        {
            PlayerStats.FireRate -= 0.1f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.FireRate);
            if (PlayerStats.FireRate <= 0.5f)
            {
                fireRate.interactable = false;
            }
        }
    }
    public void NumberOfBullets () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.NumberOfBullets < 5)
        {
            PlayerStats.NumberOfBullets++;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.NumberOfBullets);
            if (PlayerStats.NumberOfBullets >= 5)
            {
                numberOfBullets.interactable = false;
            }
        }
    }
    public void SwingSpeed () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.SwingSpeed > 0.52f)
        {
            PlayerStats.SwingSpeed -= 0.09f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.SwingSpeed);
            if (PlayerStats.SwingSpeed <= 0.52f)
            {
                swingSpeed.interactable = false;
            }
        }
    }
    public void ChargeLength () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.ChargeLength < 3000.0f)
        {
            PlayerStats.ChargeLength += 200.0f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.ChargeLength);
            if (PlayerStats.ChargeLength >= 3000.0f)
            {
                chargeLength.interactable = false;
            }
        }
    }
    public void SwingSize () {
        if (PlayerStats.UpgradeCoins > 0 && PlayerStats.SwingSize < 1.8f)
        {
            PlayerStats.SwingSize += 0.16f;
            PlayerStats.UpgradeCoins--;
            Debug.Log(PlayerStats.SwingSize);
            if (PlayerStats.SwingSize >= 1.8f)
            {
                swingSize.interactable = false;
            }
        }
    }
    public void NextLevel () {
        var level = "Level" + ++PlayerStats.Level;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
