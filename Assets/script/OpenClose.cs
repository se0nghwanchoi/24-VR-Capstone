using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenClose : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // ÂüÁ¶ÇÒ XRGrabInteractable
    public Animator openandclose;
    public bool open;

    void Start()
    {
        open = false;
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
                if (open == false)
                {                   
                        StartCoroutine(opening());                  
                }
                else
                {
                    if (open == true)
                    {                        
                            StartCoroutine(closing());                    
                    }

                }
            }
        
        IEnumerator opening()
    {
        print("you are opening the door");
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }


}
