using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAndScore : MonoBehaviour
{
    bool isAlive;
    int coins;
    float time = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timeText;

    void Start()
    {
        isAlive = true;
        coinText.text = "Coins: " + coins.ToString("D3");
    }

    void Update()
    {
        if (isAlive == true)
        {
            time += Time.deltaTime;
            timeText.text = "Time: " + time.ToString("F2");
        }
        
    }
    public void CoinUp()
    {
        coins++;
        coinText.text = "Coins: "+coins.ToString("D3");
    }
    public void Stop()
    {
        isAlive = false;
    }
}
