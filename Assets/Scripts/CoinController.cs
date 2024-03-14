using UnityEngine;

public class CoinController : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 300f, 0);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore(1);
        }
    }
}
