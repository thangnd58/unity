using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPerfab;
    public Transform bulletSpawnPoint;

    public float speed = 100.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 0, speed * Time.deltaTime * 50);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 0, -speed * Time.deltaTime * 50);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPerfab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(bulletSpawnPoint.up * 10, ForceMode2D.Impulse);
    }
}
