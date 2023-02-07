using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RandomWalkerGenrator : MonoBehaviour
{
    [SerializeField]
    GameObject walkerPrefab;

    Timer timer;

    public float timeGenerateWalker;


    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval = timeGenerateWalker;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinished())
        {
            Instantiate<GameObject>(walkerPrefab, Vector2.zero, Quaternion.identity);
        }
    }
}
