using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Breakwindow : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // ������ XRInteractable
    public Transform createPoint;
    public GameObject window;
    public Transform destroyEffectPrefab;
   

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
        Destroy(window);
        // ��ƼŬ ����
        Transform particleInstance = Instantiate(destroyEffectPrefab, createPoint.position, createPoint.rotation, createPoint);
        
    }
}
