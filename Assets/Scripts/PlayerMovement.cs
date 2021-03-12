using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public bool canSlide = false;
    public float slideSpeed;

    public float jumpForce;
    private float dirnInp;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkWidth;
    public LayerMask whatisSurface;

    private int extraJumpsVal=0;
    private int jumpCount;

    private bool isLeft;
    public Transform leftWallCheck;

    private bool isRight;
    public Transform rightWallCheck;

    private bool hasJumped;
    private Vector3 lmao;
    private Vector3 lmao2;

    private Rigidbody2D rb;

    public UnityAction jumpAction;
    public UnityAction landAction;

    private void Start()
    {
        jumpCount = 0;
        hasJumped = false;
        rb = GetComponent<Rigidbody2D>();
        lmao = GetComponent<Collider2D>().bounds.extents;
        lmao.y = checkWidth;
        lmao2 = GetComponent<Collider2D>().bounds.extents;
        lmao2.x = checkWidth;
    }

    public void EnableDoubleJump()
    {
        extraJumpsVal = 1;
    }
    public void DisableDoubleJump()
    {
        extraJumpsVal = 0;
    }

    public void EnableSlide()
    {
        canSlide = true;
    }
    private void FixedUpdate()
    {
        if (facingRight == false && dirnInp > 0f)
        {
            Flip();
        }
        else if (facingRight == true && dirnInp < 0f)
        {
            Flip();
        }

        if (canSlide == true && isGrounded)
        {
            Vector2 slidee = new Vector2(dirnInp, 0f);
            rb.velocity=(slidee * slideSpeed);
        }
        if (hasJumped == true && isGrounded && rb.velocity.x != 0f && canSlide==false)
        {
            rb.velocity = Vector2.zero;
            hasJumped=false;
            landAction?.Invoke();
        }

    }

    private void Update()
    {
        dirnInp = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapBox(groundCheck.position, lmao, 0f, whatisSurface);
        isLeft = Physics2D.OverlapBox(leftWallCheck.position, lmao2, 0f, whatisSurface);
        isRight = Physics2D.OverlapBox(rightWallCheck.position, lmao2, 0f, whatisSurface);


        Debug.Log(extraJumpsVal);
        if (isGrounded == true)
        {
            jumpCount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (jumpCount <= extraJumpsVal)
            {
                Debug.Log(jumpCount);
                Vector2 jumpp = new Vector2(0f, 1f);
                rb.velocity = Vector2.zero;
                if (dirnInp > 0) jumpp = new Vector2(1.5f, 1.25f);
                else if (dirnInp < 0) jumpp = new Vector2(-1.5f, 1.25f);
                else if (dirnInp == 0) jumpp = new Vector2(0f, 1.25f);
                rb.AddForce(jumpp * jumpForce);
                hasJumped = true;
                jumpCount++;
                Debug.Log(jumpCount);
                jumpAction?.Invoke();

            }
            else if (isLeft == true && isGrounded == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                Vector2 jumpp = new Vector2(1f, 2f);
                rb.AddForce(jumpp * jumpForce);
                hasJumped = true;
                jumpAction?.Invoke();

            }
            else if (isRight == true && isGrounded == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                Vector2 jumpp = new Vector2(-1f, 2f);
                rb.AddForce(jumpp * jumpForce);
                hasJumped = true;
                jumpAction?.Invoke();

            }


        }

        

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        GetComponentInChildren<SpriteRenderer>().flipX = !facingRight;
    }

}
