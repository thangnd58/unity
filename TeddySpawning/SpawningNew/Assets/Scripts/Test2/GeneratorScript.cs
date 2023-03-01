using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject generatorPrefab;

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval = 1;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinished())
        {
            Instantiate<GameObject>(generatorPrefab, Vector2.zero, Quaternion.identity);
        }
    }
}
