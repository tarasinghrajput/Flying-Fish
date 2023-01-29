using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public Sprite flapUp;
    public Sprite flapDown;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip flapSwing;
    public AudioClip backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // Set the starting sprite
        GetComponent<SpriteRenderer>().sprite = flapUp;
        audioSource.PlayOneShot(backgroundMusic, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        StartCoroutine(FishFly());

        if(transform.position.y > 13 || transform.position.y < -13)
        {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    public void soundScore()
    {
        audioSource.PlayOneShot(scoreSound, 0.8f);
    }

    public IEnumerator FishFly()
    {
        if(Input.GetMouseButton(0) == true && birdIsAlive == true)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        changingSprite();
        yield return new WaitForSeconds(.5f);
            
        }
    }

    public void changingSprite()
    {
        // Get the current sprite
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;

            // If the current sprite is sprite1, set it to sprite2
            if (currentSprite == flapUp)
            {
                GetComponent<SpriteRenderer>().sprite = flapDown;
                // audioSource.PlayOneShot(flapSwing, 0.5f);
            }
            // If the current sprite is sprite2, set it to sprite1
            else
            {
                GetComponent<SpriteRenderer>().sprite = flapUp;
                // audioSource.PlayOneShot(flapSwing, 0.5f);
            }
    }
}
