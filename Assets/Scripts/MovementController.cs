using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;
    Animator animator;
    Joystick joystick;
    string animationState = "AnimationState";

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
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (joystick.Horizontal > .5)
            {
                movement.x = 1;
            } else if (joystick.Horizontal < -.5)
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
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

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
    }
}
