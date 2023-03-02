using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject generatorPrefab;

    int health;

    public static Dictionary<int, GameObject> listSaveLoad = new Dictionary<int, GameObject>();

    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.interval = 10;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.isFinished())
        {
            health = Random.Range(1, 4);
            generatorPrefab.transform.localScale = new Vector3(health, health, 1);
            float posX = Random.Range(-Camera.main.orthographicSize * Screen.width / Screen.height,
                               Camera.main.orthographicSize * Screen.width / Screen.height);
            float posY = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
            generatorPrefab.transform.position = new Vector2(posX, posY);
            GameObject o =  Instantiate<GameObject>(generatorPrefab, generatorPrefab.transform.position, Quaternion.identity);
            o.GetInstanceID();
            listSaveLoad.Add(o.GetInstanceID(), o);
        }
    }
}
