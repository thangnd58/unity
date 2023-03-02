using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillScript : MonoBehaviour
{
    Timer timer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval = 2;
        timer.Run();
    }

    private void Update()
    {
        if (timer.isFinished())
        {
            Destroy(gameObject);
        }
    }
}
