using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Glide : MonoBehaviour
{
    private bool isGrounded;
    public Transform groundCheck;
    public float checkWidth;
    public LayerMask whatisSurface;
    private Vector3 lmao;
    private Rigidbody2D rb;
    public float upForce;
    public float glideMoveSpeed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lmao = GetComponent<Collider2D>().bounds.extents;
        lmao.y = checkWidth;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, lmao, 0f, whatisSurface);
        if (isGrounded == false && Input.GetKey(KeyCode.Space))
        {
            Vector2 upp = new Vector2(0, upForce);
            rb.AddForce(upp);

            float inpp = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(inpp * glideMoveSpeed, rb.velocity.y);
        }
    }
}
