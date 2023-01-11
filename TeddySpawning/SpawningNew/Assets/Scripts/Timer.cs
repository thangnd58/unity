using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // timer duration
    public float interval;

    // timer execution
    float elapsedSeconds = 0;
    public bool running = false;

    public void Start()
    {
        elapsedSeconds = 0;
        running = true;
    }

    private void Update()
    {
        if (elapsedSeconds >= interval)
        {
            elapsedSeconds = 0;
            running = false;
        }
        else
        {
            running = true;
            elapsedSeconds += Time.deltaTime;
        }
    }
}
