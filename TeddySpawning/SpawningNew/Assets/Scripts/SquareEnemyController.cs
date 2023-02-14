using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SquareEnemyController : MonoBehaviour
{

    [SerializeField]
    GameObject prefabExplosion;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        float posX = Random.Range(-Camera.main.orthographicSize * Screen.width / Screen.height,
                                Camera.main.orthographicSize * Screen.width / Screen.height);
        float posY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector2(posX, posY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BallKillSquare")
        {
            Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
