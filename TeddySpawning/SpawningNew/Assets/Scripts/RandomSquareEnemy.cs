using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSquareEnemy : MonoBehaviour
{
    [SerializeField]
    public GameObject squarePrefab;

    Timer timer;

    public float timeGeneratorSquare;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval = timeGeneratorSquare;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinished())
        {
            Instantiate<GameObject>(squarePrefab, Vector2.zero, Quaternion.identity);
        }
    }
}
