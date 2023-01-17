using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBearCollector : MonoBehaviour
{


    [SerializeField]
    GameObject perfabPickup;

    Timer timer;

    List<GameObject> pickups = new List<GameObject>();

    public GameObject TargetPickup
    {
        get
        {
            if (pickups.Count > 0)
            {
                return pickups[0];
            }
            else
            {
                return null;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            GameObject pickup = Instantiate(perfabPickup);
            pickup.transform.position = worldPosition;
            pickups.Add(pickup);
        }
    }

    public void RemovePickup(GameObject pickup)
    {
        pickups.Remove(pickup);
        Destroy(pickup);
    }
}
