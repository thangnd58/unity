using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    float colliderHalfWidth;
    float colliderHalfHeight;

    void Start()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        colliderHalfWidth = collider2D.size.x / 2;
        colliderHalfHeight = collider2D.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);

        transform.position = position;
        ClampInScreen();
    }

    void ClampInScreen()
    {
        Vector3 position = transform.position;

        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }

        if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        }
        transform.position = position;
    }
}
