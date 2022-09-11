using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject heroCopy;
    public float speed = 2f;

    public GameObject bullet;
    public Transform point;
    private bool canShoot = false;

    AudioSource sourse;
    public AudioClip shoot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1f, 1.5f);
        sourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - heroCopy.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 30)
        {
            angle = 30;
        }
        if (angle > 150)
        {
            angle = 150;
        }
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Hero")
        {
            Debug.Log("Hero comes");
            canShoot = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            Debug.Log("Hero leaves");
            canShoot = false;
        }
    }

    void Shoot()
    {
        if (canShoot)
        {
            GameObject go = GameObject.Instantiate(bullet, point.transform.position, Quaternion.identity) as GameObject
                ;
            go.GetComponent<Rigidbody2D>().AddForce(0.05f * -point.right);
            sourse.PlayOneShot(shoot);
        }
    }
}
