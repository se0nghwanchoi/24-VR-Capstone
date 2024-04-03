using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisher : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // ÂüÁ¶ÇÒ XRGrabInteractable
    public Animator animFire;
    public Transform particle;
    public Transform createPoint;
    
    
      
          
    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(HandleSelectEntered);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(HandleSelectEntered);
    }

    private void HandleSelectEntered(SelectEnterEventArgs arg)
    {
        animFire.SetBool("Push_Btn", true);
        
        Instantiate(particle, createPoint.position, createPoint.rotation, createPoint);
        
    }




}
