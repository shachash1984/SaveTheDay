using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

    public int score;

    private bool CoinTaken;    
    private int coinScore = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        CoinTaken = true;
        if(CoinTaken)
        {
            score = 1 * coinScore;
            gameObject.SetActive(false);

           
        }
    }
    
   
}
