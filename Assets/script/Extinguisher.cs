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
    public Transform particlePrefab; // ���������� ����

    void Start()
    {
        XRGrabInteractable XGI = GetComponent<XRGrabInteractable>();

        XGI.activated.AddListener(FireEx);
    }

    public void FireEx(ActivateEventArgs arg)
    {
        animFire.SetBool("Push_Btn", true);
        //��ƼŬ ����
        Transform particleInstance = Instantiate(particlePrefab, createPoint.position, createPoint.rotation, createPoint);

        // 2�� �ڿ� Push_Btn ���¸� ������Ŵ
        StartCoroutine(ReversePushBtnAfterDelay());
    }

    IEnumerator ReversePushBtnAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        animFire.SetBool("Push_Btn_Reverse", true);
    }
}
