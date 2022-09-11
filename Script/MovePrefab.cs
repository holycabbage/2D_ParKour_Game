using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public GameObject hero, prefabToMove;
    private float incrementX;
    private static int count;

    public GameObject fuelCan;  //, gun, laser;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        incrementX = 76.6f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            count++;
            Debug.Log("Prefab was moved " + count + "times.");

            if (count >= 2)
            {
                prefabToMove.transform.position = new Vector2(prefabToMove.transform.position.x + incrementX,
                    prefabToMove.transform.position.y);               

                fuelCan.SetActive(true);
                fuelCan.transform.localPosition = new Vector3(Random.Range(-12f, 10f), Random.Range(-2.7f, 1f), transform.localPosition.z);

                //gun.transform.localPosition = new Vector3(Random.Range(-12f, 10f), transform.localPosition.y, transform.localPosition.z);
                //laser.transform.localPosition = new Vector3(Random.Range(-12f, 10f), transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
