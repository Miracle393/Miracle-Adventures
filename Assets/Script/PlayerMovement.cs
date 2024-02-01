using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

  private Rigidbody2D rb;
  private BoxCollider2D bc;
  private SpriteRenderer sprite;
  private Animator anim;

  [SerializeField] private LayerMask jumpableGround;

  private float dirX = 0f;
  [SerializeField] private float moveSpeed = 7f;
  [SerializeField] private float jumpForce = 10f;

  private enum MovementState { idle, running, jumping, falling }

  [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {  
       // Debug.Log("Hello there Pixal Adventure 2");
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       bc = GetComponent<BoxCollider2D>();
       sprite =GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
      //movement along x-axis
      dirX = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

      //movement along y-axis
      if (Input.GetButtonDown("Jump") && IsGrounded())
      {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      } 


      updateAnimationUpdate();
    }

    private void updateAnimationUpdate() 
    {

        MovementState state;


      if (dirX > 0f)
      {
        state = MovementState.running;
        sprite.flipX = false;
      } 
      else if (dirX < 0f)
      {
        state = MovementState.running;
        sprite.flipX= true;
      }
      else
      {
        state = MovementState.idle;
      }

      if(rb.velocity.y > .1f)
      {
        state = MovementState.jumping;
      }
      else if (rb.velocity.y < -.1f)
      {
        state = MovementState.falling;
      }

      anim.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
      return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
