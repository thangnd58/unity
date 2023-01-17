using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Jumps the game object to a new location every second
/// </summary>
public class BallBounce : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    Rigidbody2D rb;

    Timer timer;

    int health = 5;

    BallGenerator ballGenerator;

    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval = 10;
        timer.Run();
        rb = GetComponent<Rigidbody2D>();
        //const float MinImpulseForce = 3f;
        //const float MaxImpulseForce = 5f;
        //float angle = Random.Range(0, 2 * Mathf.PI);
        //Vector2 direction = new Vector2(
        //    Mathf.Cos(angle), Mathf.Sin(angle));
        //float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        //GetComponent<Rigidbody2D>().AddForce(
        //    direction * magnitude,
        //    ForceMode2D.Impulse);
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(3f, 5f);
        rb.AddForce(magnitude * direction, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //if (!timer.isFinished())
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BallTag")
        {
            health--;
            if (health <= 0)
            {
                Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
