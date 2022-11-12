using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public LoadAds loadAds;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    bool adOpend;

    void Awake()
    {
        health = 3;
        adOpend = false;
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

        if (health == 0)
        {
            
            if (!adOpend)
            {
                loadAds.ShowInterstitial();
                adOpend = true;
            }

        }
    }

    
    
}
