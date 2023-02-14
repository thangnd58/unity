using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallKillSquareController : MonoBehaviour
{
    public float speed = 10.0f;

    Rigidbody2D rb;

    public TextMeshProUGUI scoreText;

    private int scoreCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        scoreText.text = "Score: " + scoreCount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SquareEnemy")
        {
            scoreCount++;
        }
    }
}
