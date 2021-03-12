using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class dash: MonoBehaviour
{

    public float dashSpeed;
    private Rigidbody2D rb;
    private float dashCount=1;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkWidth;
    public LayerMask whatisSurface;
    private Vector3 lmao;
    [Range(0f, 1f)]
    public float crushFactor;
    private bool bufferDash;
    public UnityAction dashAction;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lmao = GetComponent<Collider2D>().bounds.extents;
        lmao.y = checkWidth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bufferDash = true;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, lmao, 0f, whatisSurface);
        if (bufferDash && dashCount>0&& isGrounded==false)
        {
            bufferDash = false;
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {

                rb.velocity = Vector2.zero;
                rb.AddForce(transform.right * dashSpeed, ForceMode2D.Impulse);
                dashCount--;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(transform.right * dashSpeed * -1f, ForceMode2D.Impulse);
                dashCount--;
            }
            else
            {
                float dirn = rb.velocity.x;
                Vector2 dirnn = new Vector2(dirn, 0);
                rb.velocity = Vector2.zero;
                rb.AddForce(dirnn * dashSpeed, ForceMode2D.Impulse);
                dashCount--;
            }
            rb.gravityScale = 0f;
            Invoke(nameof(endDash), 0.25f);
            dashAction?.Invoke();
        }
        if (isGrounded == true)
        {
            dashCount = 1;
        }
    }

    void endDash()
    {
        rb.gravityScale = 1f;
        Vector2 velocity = rb.velocity.normalized;
        velocity *= crushFactor;
        rb.velocity = velocity;
    }
}
