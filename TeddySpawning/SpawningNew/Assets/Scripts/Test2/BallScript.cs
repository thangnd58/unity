using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;

    int health;

    [SerializeField]
    GameObject prefabExplosion;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.RandomRange(1, 4);
        float posX = Random.Range(-Camera.main.orthographicSize * Screen.width / Screen.height,
                                Camera.main.orthographicSize * Screen.width / Screen.height);
        float posY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.localScale = new Vector3(health*0.5f, health*0.5f, 1);
        gameObject.transform.position = new Vector2(posX, posY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            gameObject.transform.localScale = new Vector3(health * 0.5f, health * 0.5f, 1);
            if (health <= 0)
            {
                Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
}
