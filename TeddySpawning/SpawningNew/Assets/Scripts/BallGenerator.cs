using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject ballPerfab;

    Timer timer;



    public Vector3 pos;
    public float timeGenerateBall;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval= timeGenerateBall;
        timer.Run();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.isFinished())
        {
            Instantiate<GameObject>(ballPerfab, pos, Quaternion.identity);
        }
    }
}
