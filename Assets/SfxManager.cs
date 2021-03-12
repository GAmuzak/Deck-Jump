using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public AudioSource jumpSource;

    private void Start()
    {
        playerMovement.jumpAction += OnJump;
    }
    private void OnDisable()
    {
        playerMovement.jumpAction -= OnJump;
    }
    public void OnJump()
    {
        jumpSource.Play();
    }
}
