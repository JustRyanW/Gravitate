using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

    [Header("Planet Options")]
    [Range(1,20)]
    public float scale;
    [Range(0.1f,20)]
    public float mass;

    [Header("Coin Settings")]
    public bool hasCoins;
    public GameObject coinPrefab;
    [Range(0, 5)]
    public float coinDistance;
    [Range(2, 20)]
    public int coinAmount;
    public Vector2 coinAngles;
    
    Vector2[] coinLocations;

	void Start ()
    {
        if (hasCoins)
        {
            GetCoins(false);
            for (int i = 0; i < coinLocations.Length; i++)
            {
                Instantiate(coinPrefab, coinLocations[i], Quaternion.identity);
            }
        }
	}
	
	void Update () {
	
	}

    void GetCoins(bool drawGizmos)
    {
        coinLocations = new Vector2[coinAmount];
        Vector2 pos = transform.position;
        if (drawGizmos)
        {
            GizmosController.DrawPlus(GizmosController.AngleToVector2(coinAngles.x, coinDistance + scale / 2) + pos, 0.5f, Color.blue);
            GizmosController.DrawPlus(GizmosController.AngleToVector2(coinAngles.y, coinDistance + scale / 2) + pos, 0.5f, Color.blue);
        }

        float size = 0.3f;
        for (int i = 0; i < coinLocations.Length; i++)
        {
            coinLocations[i] = GizmosController.AngleToVector2(Mathf.Lerp(coinAngles.x, coinAngles.y, (float)i / (coinLocations.Length - 1)), coinDistance + scale / 2) + pos;
            if (drawGizmos)
            {
                GizmosController.DrawCross(coinLocations[i], size);
            }
            //Debug.Log((float)i/coinLocations.Length);
        }
    }

    void OnDrawGizmos()
    {
        transform.localScale = new Vector2(scale,scale);
        GetComponent<Rigidbody2D>().mass = mass;
        if (hasCoins)
        {
            GetCoins(true);
        }
    }

}
