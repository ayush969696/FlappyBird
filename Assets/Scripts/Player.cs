using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    public AudioSource playerFly;
    public AudioClip playerLose;
    public AudioClip scoresound;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            playerFly.Play();
        }
        if (Input.touchCount > 0)        // it means when user touch the screen multiple time then it will take only one touch 
        {
            Touch touch = Input.GetTouch(0);  

            if(touch.phase == TouchPhase.Began)        // it will tell us that user just touch the screen
            {
                direction = Vector3.up * strength;
                playerFly.Play();
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];  // here we are updating the sprite rendererv
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            FindObjectOfType<GameManager>().GameOver();    // it is not good function to use but its ok for this game
            playerFly.PlayOneShot(playerLose);

        } else if(collision.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            playerFly.PlayOneShot(scoresound);
        }
    }
}
