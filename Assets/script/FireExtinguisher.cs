using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisher : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // ������ XRInteractable
    public Animator animFire;
    public Transform particlePrefab; // ���������� ����
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
