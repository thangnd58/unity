using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour
{
    const float ImpulseForceMagnitude = 2.0f;

    bool collecting = false;
    GameObject targetPickup;

    Rigidbody2D rb;
    TeddyBearCollector teddyBearCollector;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;

        rb = GetComponent<Rigidbody2D>();
        teddyBearCollector = Camera.main.GetComponent<TeddyBearCollector>();

    }

    private void OnMouseDown()
    {
        if (!collecting)
        {
            GoToNextPickUp();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == targetPickup)
        {
            teddyBearCollector.RemovePickup(targetPickup);
            rb.velocity = Vector3.zero;
            GoToNextPickUp();
        }
    }

    void GoToNextPickUp()
    {
        targetPickup = teddyBearCollector.TargetPickup;
        if (targetPickup != null)
        {
            Vector2 direction = new Vector2(targetPickup.transform.position.x - transform.position.x, targetPickup.transform.position.y - transform.position.y);
            direction.Normalize();
            rb.AddForce(direction * ImpulseForceMagnitude, ForceMode2D.Impulse);
        }
    }
}
