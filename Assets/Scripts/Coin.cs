using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            GameManager.numberofCoins++;
            AudioManager.instance.Play("Coins");
           PlayerPrefs.SetInt("NumberOfCoins", GameManager.numberofCoins);
            Destroy(gameObject);
        }
    }
}
