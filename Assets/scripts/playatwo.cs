using UnityEngine;
using System.Collections;

public class playatwo : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int extraJump;
    public int extraJumpValue;
    private bool facingRight = true;
    public AudioSource jumpsound;
    public Vector3 spawnn;
    void Start()
    {
        spawnn = transform.position;
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
       
    }



    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;

            if (facingRight == false)
            {
                Flip();
            }

            /*if(transform.localScale.x == -.227f)
            {
                transform.localScale = new Vector3(.227f, transform.localScale.y, transform.localScale.z);
            }*/

        }

        if (Input.GetKey(KeyCode.Q))
        {
            pos.x -= speed * Time.deltaTime;

            if (facingRight == true)
            {
                Flip();

            }

            /*if (transform.localScale.x == .227f)
            {
                transform.localScale = new Vector3(-.227f, transform.localScale.y, transform.localScale.z);
            }*/

        }
        transform.position = pos;


    }




    void Update()
    {
       
        if (isGrounded == true)
        {
          
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Z) && extraJump > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJump--;
            jumpsound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Z) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
        }

        if (transform.position.y <-15)
        {
            die();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "goal2")
        {
            GameManager.instance.SetBool(2, true);
        } else if(other.CompareTag("portal1"))
        {
            StartCoroutine(PortalRoutine(other.transform.Find("PortPoint").transform.position));
          
        }
        else
              if (other.transform.tag == "enemy")
        {
            die();
        }
        else 
            if (other.transform.tag =="Bullet")
        {
            die(); 
        }
   
    }





    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "goal2")
        {
            GameManager.instance.SetBool(2, false);
        }
    }

    private IEnumerator PortalRoutine (Vector3 newValue) {
        yield return new WaitForSeconds(.2f);
        transform.position = newValue;
    }
    void die()
    {
       
        transform.position = spawnn;
    }
}
