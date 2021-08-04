using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extraJumpValue;
    public AudioSource jumpsound;
    private Vector3 spawn;
   
  
    void Start()
    {
        spawn = transform.position;
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
      
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);



        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
          
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
           
        }

    }

    void Update()
    {

        

        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJump--;
            jumpsound.Play();
        }
       
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;

        }
        if (transform.position.y < -10)
        {
            die();
        }
       
    }
    

    

    private void Flip()
    {
        facingRight = !facingRight;

   
        transform.Rotate (0f,180f,0f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "goal1")
        {
            GameManager.instance.SetBool(1, true);
        }
        else if (other.CompareTag("bortal1"))
        {
            StartCoroutine(PortalRoutine(other.transform.Find("PortPoint2").transform.position));

        }
        else
            if (other.transform.tag == "enemy")
        {
            die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "goal1")
        {
            GameManager.instance.SetBool(1, false);
        }
    }
    private IEnumerator PortalRoutine(Vector3 newValue)
    {
        yield return new WaitForSeconds(.2f);
        transform.position = newValue;
    }
    void die()
    {
        
        transform.position = spawn;
    }

}



