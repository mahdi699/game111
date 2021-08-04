using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    
    public float speed = 20f;
    public Rigidbody2D rrb;
    // Start is called before the first frame update

    private void Awake()
    {  
    rrb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate ()
    {
            
            rrb.velocity = Vector2.left * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D col )
    {
        if (col.transform.tag == "enemy")
        {
            Debug.Log("hit enemy ");
            Destroy(gameObject);

        }
    }
    // Update is called once per frame                  

}
