using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public GameObject coinPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // coinPrefab = GameObject.Find("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.Rotate(0, 0, 1, Space.Self);
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            // Vector3 randomPosition = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
            // Instantiate(coinPrefab, randomPosition, Quaternion.identity);
            ScoreManager.instance.AddScore(1);
        }
    }
}
