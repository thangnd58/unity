using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class RandomWalkerController : MonoBehaviour
{
    float posX, posY;
    Vector2 spawnPosition;
    Rigidbody2D rb;
    float speed = 5.0f;
    int health = 5;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject prefabExplosion;

    void Start()
    {
        posX = 0;
        posY = 0;
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector2(posX, posY);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distance = Vector2.Distance(gameObject.transform.position, spawnPosition);
        if (distance <= 0.01f)
        {
            posX = Random.Range(-Camera.main.orthographicSize * Screen.width / Screen.height,
                                Camera.main.orthographicSize * Screen.width / Screen.height);
            posY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
            spawnPosition = new Vector2(posX, posY);
        }
        else
        {
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, spawnPosition, Time.deltaTime * speed / distance);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            if (health == 1)
            {
                spriteRenderer.color = new Color(1, 0, 0, 1);
            }
            if (health <= 0)
            {
                Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
}
