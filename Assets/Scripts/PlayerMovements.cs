using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerMovements : MonoBehaviour
{
    PlayerControls controls;
    float movedirection = 0;
    public Rigidbody2D rb;
    public float movespeed;

    public Animator animator;
    public bool isFacingRight = true;
    public float jumpForce = 0;
    public LayerMask groundLayer;

    bool isGrounded;
    public Transform groundCheck;

    int numofjumps = 0;

  
    
  
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += context =>
        {
            movedirection = context.ReadValue<float>();
        };
        controls.Land.Jump.performed += context => Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        rb.velocity = new Vector2(movedirection * movespeed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(movedirection));

        if (isFacingRight && movedirection < 0 || !isFacingRight && movedirection > 0)
            FlipPlayer();
    }


    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }


    void Jump()
    {
        if (isGrounded)
        {
            numofjumps = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numofjumps++;
            AudioManager.instance.Play("FirstJump");
        }
        else
        {
            if(numofjumps == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                numofjumps++;
                AudioManager.instance.Play("SecondJump");
            }
        }
        
    }
}   