using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class SwapCam : MonoBehaviour
{
    private CinemachineVirtualCamera overViewCam;

    private void Start()
    {
        overViewCam = transform.GetChild(1).GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (Input.anyKey && !EventSystem.current.IsPointerOverGameObject())
        {
            overViewCam.Priority=0;
            this.enabled = false;
        }
    }
}
