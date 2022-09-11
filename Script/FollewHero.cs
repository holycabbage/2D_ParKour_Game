using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollewHero : MonoBehaviour
{
    public GameObject heroCopy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= heroCopy.transform.position.x)
        {
            transform.position = new Vector2(heroCopy.transform.position.x, transform.position.y);
        }
        
    }
}
