using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;

    int health;

    [SerializeField]
    public GameObject prefabExplosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = int.Parse(gameObject.transform.localScale.x.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            gameObject.transform.localScale = new Vector3(health, health, 1);
            if (health <= 0)
            {
                Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GeneratorScript.listSaveLoad.Remove(gameObject.GetInstanceID());
            }
        }

    }
}
