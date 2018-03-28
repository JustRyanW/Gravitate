using UnityEngine;
using System.Collections;

public class CoinIdentifier : MonoBehaviour {

	public static int maxCoinGroup;

    public int coinGroup;
    public int coinNumber;
	public bool isCollected;

    TextMesh coinText;

	void Start () {
        coinText = GetComponentInChildren<TextMesh>();
		coinText.text = (coinNumber + 1).ToString() ;
		CoinController.SetCoin (coinGroup ,coinNumber , gameObject.GetComponent<CoinIdentifier>());
		if (coinGroup > maxCoinGroup) 
		{
			maxCoinGroup = coinGroup;
		}
		if (coinNumber > 0) 
		{
			gameObject.GetComponent<Collider2D> ().enabled = false;
		}
	}

	void OnTriggerEnter2D(){
		bool isCollected = true;
		CoinController.CollectCoin (coinGroup, coinNumber);
		Destroy (gameObject);
	}
}
