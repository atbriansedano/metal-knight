using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public AudioClip moveSound; // Sound to play when moving
    public float moveSpeed = 5f; // Speed of horizontal movement

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Get horizontal input axis (left or right arrow key, or A or D key)
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check if character is moving horizontally
        if (horizontalInput != 0 && !isMoving)
        {
            isMoving = true;
            PlayMoveSound();
        }
        else if (horizontalInput == 0 && isMoving)
        {
            isMoving = false;
        }

        // Move character horizontally
        Vector2 velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;
    }

    void PlayMoveSound()
    {
        // Play move sound
        if (moveSound != null)
        {
            audioSource.clip = moveSound;
            audioSource.Play();
        }
    }
}

