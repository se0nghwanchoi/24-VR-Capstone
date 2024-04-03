using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisher : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // ������ XRGrabInteractable
    public Animator animFire;
    public Transform particle;
    public Transform createPoint;

    void Start()
    {

    }

    void OnEnable()
    {
        simpleInteractable.selectEntered.AddListener(HandleSelectEntered);
    }

    void OnDisable()
    {
        simpleInteractable.selectEntered.RemoveListener(HandleSelectEntered);
    }

    private void HandleSelectEntered(SelectEnterEventArgs arg)
    {
        animFire.SetBool("Push_Btn", true);

         // ��ƼŬ ����
        Instantiate(particle, createPoint.position, createPoint.rotation);
            
        
    }
}
