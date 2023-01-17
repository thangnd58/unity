using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{

    [SerializeField]
    GameObject perfabCharacter0;

    [SerializeField]
    GameObject perfabCharacter1;

    [SerializeField]
    GameObject perfabCharacter2;

    [SerializeField]
    GameObject perfabCharacter3;

    GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = Instantiate(perfabCharacter0, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //left mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = currentCharacter.transform.position;
            Destroy(currentCharacter);

            int perfabNumber = Random.Range(0, 3);

            if(perfabNumber == 0)
            {
                currentCharacter = Instantiate(perfabCharacter0, position, Quaternion.identity);
            } else if (perfabNumber == 1)
            {
                currentCharacter = Instantiate(perfabCharacter1, position, Quaternion.identity);
            }
            else if (perfabNumber == 2)
            {
                currentCharacter = Instantiate(perfabCharacter2, position, Quaternion.identity);
            }
            else if (perfabNumber == 3)
            {
                currentCharacter = Instantiate(perfabCharacter3, position, Quaternion.identity);
            }
        }
    }
}
