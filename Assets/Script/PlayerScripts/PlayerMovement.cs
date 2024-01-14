using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 0.01f;
    public Animator movement;
    Vector2 movementPosition;
    public Rigidbody2D rb;
    bool facingRight = true;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        //get their movement either using WASD or Arrows 
        movementPosition.x = Input.GetAxisRaw("Horizontal");
        movementPosition.y = Input.GetAxisRaw("Vertical");

        movement.SetFloat("Horizontal", movementPosition.x);
        movement.SetFloat("Vertical", movementPosition.y);
        movement.SetFloat("Speed", movementPosition.sqrMagnitude);


        //if they are facing right and go left, invert the character 
        if (movementPosition.x < 0 && facingRight)
        {
            flip();
            
            
        }
        //if they are facing left and want to go right, invert the character
        if (movementPosition.x > 0 && !facingRight)
        {
            flip();
        }


        PosMov();
    }
    //move the character by a fixed amount with fixed time 
    void PosMov()
    {
        rb.MovePosition(rb.position+movementPosition * movementSpeed * Time.fixedDeltaTime);
    }

    void flip()
    {
        facingRight = !facingRight;

        // Get the current local scale of the character
        Vector3 localScale = transform.localScale;

        // Flip the character's sprite horizontally by inverting the X scale
        localScale.x *= -1;

        // Apply the new local scale to the character
        transform.localScale = localScale;
    }

}
