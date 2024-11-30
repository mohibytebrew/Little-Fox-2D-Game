using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;
    public float jumpforce;
    bool isgrounded;
    public Transform groundcheckpoint;
    public LayerMask whatisground;
    bool CanDoubleJump;
    public Animator anim;
    public SpriteRenderer sprite;
    void Update()
    {
        rb.velocity = new Vector2(movespeed * Input.GetAxis("Horizontal"), rb.velocity.y);

        isgrounded=Physics2D.OverlapCircle(groundcheckpoint.position, 0.2f, whatisground);

        if(isgrounded){
            CanDoubleJump = true;
        }
        if(Input.GetButtonDown("Jump")){

            if(isgrounded){
            rb.velocity= new Vector2(rb.velocity.x, jumpforce);
            }
            else{
                if(CanDoubleJump){
                
                    rb.velocity= new Vector2(rb.velocity.x, jumpforce);
                    CanDoubleJump = false;
                }
            }
        }

        if(rb.velocity.x <0 ){
            sprite.flipX=true;
        }else if(rb.velocity.x > 0){
            sprite.flipX= false;
        }
        anim.SetBool("isGrounded", isgrounded);
        anim.SetFloat("movespeed", Mathf.Abs(rb.velocity.x));
    }
}
