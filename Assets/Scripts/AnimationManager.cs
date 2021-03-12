using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private dash dashhh;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        dashhh = GetComponentInParent<dash>();

        playerMovement.jumpAction += OnJump;
        playerMovement.landAction += OnLand;
        dashhh.dashAction += OnDash;
        
    }

    private void OnDisable()
    {
        playerMovement.jumpAction -= OnJump;
        playerMovement.landAction -= OnLand;
        dashhh.dashAction -= OnDash;
    }
    public void OnDash()
    {
        anim.SetTrigger("dash");
    }

    public void OnLand()
    {
        anim.SetTrigger("land");

    }

    public void OnJump()
    {
        anim.SetTrigger("jump");

    } 
}
