using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    Text TextScore;
    public static int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        TextScore = GetComponent<Text>();
        TextScore.text = "Score: 100";
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = "Score: " + scoreCount.ToString();
    }
}
