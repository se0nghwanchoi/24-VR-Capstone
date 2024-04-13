using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Extinguisher : MonoBehaviour
{
    
    public Animator animFire;
    public Transform createPoint;
    public Transform particlePrefab; // 프리팹으로 변경

    void Start()
    {
        XRGrabInteractable XGI = GetComponent<XRGrabInteractable>();

        XGI.activated.AddListener(FireEx);
    }

    public void FireEx(ActivateEventArgs arg)
    {
        animFire.SetBool("Push_Btn", true);
        Transform particleInstance = Instantiate(particlePrefab, createPoint.position, createPoint.rotation, createPoint);
    }
}
