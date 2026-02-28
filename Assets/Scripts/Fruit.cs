using UnityEngine;

public class Fruit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.y < -6)
        {
            GameManager.instance.LoseFruit();
            Destroy(gameObject);
        }
    }
}