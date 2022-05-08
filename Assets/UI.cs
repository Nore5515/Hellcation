using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private float timing = 0.0f;
    public Text time;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;

    private int rewardedCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = this.transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timing > (15 * (rewardedCoins+1))){
            PlayerStats.UpgradeCoins += 1;
            rewardedCoins += 1;
        }
        timing += Time.deltaTime;
        Mathf.Round(timing);
        time.text = timing.ToString();
    }

}
