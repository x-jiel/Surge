using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    Animator animator;
    PlayerMovement playermove;
    SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playermove = GetComponent<PlayerMovement>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playermove.moveDirection.x != 0 || playermove.moveDirection.y != 0)
        {
            animator.SetBool("Move", true);

            CheckSpriteDirection();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    void CheckSpriteDirection()
    {
        if (playermove.lastHorizontalVector < 0)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false; 
        }
    }
}
