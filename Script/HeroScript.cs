using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroScript : MonoBehaviour
{
    private float health;
    private int life = 3;
    public float jumpForce;
    public float motionX;
    private bool onGround;
    private Animator anim;
    private Rigidbody2D rb;
    private int numOfFuelCan = 0;

    AudioSource sourse;
    public AudioClip collect;
    public AudioClip injury;
    public AudioClip jump;
    public AudioClip die;
    public AudioClip gameOver;
    //public AudioClip run;

    public Text lifeText;
    public Text numOfFuelCanText;

    private Renderer myRender;
    public int blinks = 2;
    public float time = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 8f;
        onGround = false;
        anim = GetComponent<Animator>();
        motionX = 0.17f;
        health = 100f;
        sourse = GetComponent<AudioSource>();
        myRender = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("up"))
        {
            if (onGround)
                {
                    sourse.PlayOneShot(jump);
                    //anim.SetTrigger("Jump");
                    anim.SetInteger("transition", 1);
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

                    onGround = false;
                }
        }

        if (Input.GetKey("right"))
        {
            //sourse.PlayOneShot(run);
            anim.SetInteger("transition", 0);
            //change the position along x-axis
            //adding to it
            transform.localScale = new Vector2(1f, 1f);
            transform.position = new Vector2(transform.position.x + motionX, transform.position.y);
        }

        if (Input.GetKey("left"))
        {
            //sourse.PlayOneShot(run);
            anim.SetInteger("transition", 0);
            //change the position along x-axis
            //sbutracting to it
            transform.localScale = new Vector2(-1f, 1f);
            transform.position = new Vector2(transform.position.x - motionX, transform.position.y);
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        if (onGround == true)
        {
            if (health > 0)
            {
                if (moveInput == 0)
                {
                    anim.SetInteger("transition", 4);
                }
            }
        }
    }


    public void OnCollisionEnter2D(Collision2D c)
    {
        //use c.GameObject.tag to identify if the object with which the hero collided
        //has the tag Crate
        //if that is true then do not use onGround = true;
        onGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "FuelCan")
        {
            numOfFuelCan = numOfFuelCan + 1;
            GameOverMenu.fuelCanNum = numOfFuelCan;
            numOfFuelCanText.text = numOfFuelCan.ToString();

            sourse.PlayOneShot(collect);
            collision.gameObject.SetActive(false);
            IncreaseHealth(10f);
        }

        if (collision.gameObject.tag == "GunBullet")
        {
            sourse.PlayOneShot(injury);
            collision.gameObject.SetActive(false);
            ReduceHealth(20f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            sourse.PlayOneShot(injury);
            ReduceHealth(20f);          
        }
    }


    public void IncreaseHealth(float increment)
    {
        health = health + increment;
        HealthBar.HealthCurrent = health;
        if (health > 100)
        {
            health = 100;
        }
        Debug.Log("Health is " + health);
    }

    public void ReduceHealth(float decrement)
    {
        BlinkHero(blinks, time);
        health = health - decrement;
        HealthBar.HealthCurrent = health;
        if(health <= 0)
        {
            sourse.PlayOneShot(die);
            //hero dies
            
            health = 0;

            if(life >1)
            {
                health = 100;
                HealthBar.HealthCurrent = health;
                anim.SetTrigger("recover");
                life -= 1;
                lifeText.text = "Life:"+life.ToString();
            }
            else
            {
                //gameOver
                sourse.PlayOneShot(gameOver);
                anim.SetTrigger("recover");
                this.enabled = false;
                lifeText.text = "Life:" + 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
        Debug.Log("Health is " + health);
    }

    void BlinkHero(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
   
}
