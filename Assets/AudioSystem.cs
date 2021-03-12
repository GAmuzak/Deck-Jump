using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioSource moosik;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        moosik.Play();
    }
}
