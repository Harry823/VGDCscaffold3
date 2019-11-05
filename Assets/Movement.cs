using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput1;
    private float moveInput2;

    private bool facingRight = true;
    private bool facingUp = true;

    private Rigidbody2D rb;
    private Rigidbody2D rd;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        /*
        moveInput1 = Input.GetAxis("Horizontal");
        moveInput2 = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInput1 * speed, rb.velocity.y);
        rd.velocity = new Vector2(moveInput2 * speed, rd.velocity.x);
        */
        if (facingRight == false && moveInput1 > 0)
        {
            Flip1();
        }
        else if (facingRight == true && moveInput1 < 0)
        {
            Flip1();
        }
        if (facingUp == false && moveInput2 > 0)
        {
            Flip2();
        }
        else if (facingUp == true && moveInput2 < 0)
        {
            Flip2();
        }
    }

    void Flip1()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void Flip2()
    {
        facingUp = !facingUp;
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }
}
