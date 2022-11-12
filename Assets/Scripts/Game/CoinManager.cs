using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;


public class CoinManager : MonoBehaviour
{
    
    public Text coinsText;
    public string product1;
    public string product2;
    public string product3;
    public string product4;
    public TextMeshProUGUI coinText;

    void Start()
    {
        //IapManager.numberOfCoins = PlayerPrefs.GetInt("Coincount",0);
        PlayerManager.numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        //coinsText.text = IapManager.numberOfCoins.ToString();
        coinText.text = PlayerManager.numberOfCoins.ToString();
    }

   



    public void OnPurchaseComplele(Product proddct)
    {
        if (proddct.definition.id == product1)
        {
          

           PlayerManager.numberOfCoins += 50;

            
            coinText.text = PlayerManager.numberOfCoins.ToString();
        
           PlayerPrefs.SetInt("CoinCount", IapManager.numberOfCoins);

           PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);

            Debug.Log("coins" + PlayerPrefs.GetInt("CoinCount"));

        }if (proddct.definition.id == product2)
        {
            

           PlayerManager.numberOfCoins += 100;

            
            coinText.text = PlayerManager.numberOfCoins.ToString();
        
           PlayerPrefs.SetInt("CoinCount", IapManager.numberOfCoins);

           PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);

            Debug.Log("coins" + PlayerPrefs.GetInt("CoinCount"));

        }if (proddct.definition.id == product3)
        {
            

           PlayerManager.numberOfCoins += 500;

            
            coinText.text = PlayerManager.numberOfCoins.ToString();
        
           PlayerPrefs.SetInt("CoinCount", IapManager.numberOfCoins);

           PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);

            Debug.Log("coins" + PlayerPrefs.GetInt("CoinCount"));

        }if (proddct.definition.id == product4)
        {
            

           PlayerManager.numberOfCoins += 1000;

            
            coinText.text = PlayerManager.numberOfCoins.ToString();
        
           PlayerPrefs.SetInt("CoinCount", IapManager.numberOfCoins);

           PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);

            Debug.Log("coins" + PlayerPrefs.GetInt("CoinCount"));

        }


    }
    public void OnPurchaseFaild(Product Proddct, PurchaseFailureReason failureReason)
    {
        Debug.Log("coins fail");
    }
}
