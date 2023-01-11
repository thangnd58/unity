using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject teddyPerfab;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval= 2;
        timer.Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.running)
        {
            Instantiate(teddyPerfab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
