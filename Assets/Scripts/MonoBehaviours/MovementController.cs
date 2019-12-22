using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
	Vector2 lastMovement = new Vector2();
	Rigidbody2D rb2D;
    Animator animator;
    Joystick joystick;
    string animationState = "AnimationState";
    public Deer deer;
	public float delayTime = 0.3f;
	private float counter = 0f;
	public AudioClip deerMissleSound;
	AudioSource audioSource;

	enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

	// Start is called before the first frame update
	void Start()
    {
		audioSource = FindObjectOfType<AudioSource>();
		animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
		if (joystick.Horizontal != 0 || joystick.Vertical != 0)
		{
			if (joystick.Horizontal > .5)
			{
				movement.x = 1;
			}
			else if (joystick.Horizontal < -.5)
			{
				movement.x = -1;
			}
			if (joystick.Vertical > .5)
			{
				movement.y = 1;
			}
			else if (joystick.Vertical < -.5)
			{
				movement.y = -1;
			}
			lastMovement.x = movement.x;
			lastMovement.y = movement.y;
		}
		else
		{
			movement.x = Input.GetAxisRaw("Horizontal");
			movement.y = Input.GetAxisRaw("Vertical");
			if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) { 
			    lastMovement.x = movement.x;
			    lastMovement.y = movement.y;
		    }
		}

		lastMovement.Normalize();
		movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }


		if (deer != null && Input.GetKeyDown(KeyCode.Space) && counter > delayTime)
		{
			Deer newDeer = (Deer) Instantiate(deer, transform.position, transform.rotation);
			newDeer.velocity = lastMovement * movementSpeed * 1.1f;
			audioSource.PlayOneShot(deerMissleSound, 0.7f);
			counter = 0;
		}
		counter += Time.deltaTime;
	}
}
