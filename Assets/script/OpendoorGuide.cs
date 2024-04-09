using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OpendoorGuide : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // ������ XR
    public Animator openandclose;
    public bool open;
    public GameObject arrow; // ȭ��ǥ ��ü
    public AudioClip broadcast; // �ȳ� ��� ����� Ŭ��
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

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
        
        openandclose.Play("Opening");
        open = true;
        audioSource.clip = broadcast;
        audioSource.Play();
        Invoke("ShowArrow", broadcast.length); // ��� ���� �� ȭ��ǥ ǥ��
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }
    void ShowArrow()
    {
        arrow.SetActive(true);
        Invoke("HideArrow", 20); // 20�� �� ȭ��ǥ ����
    }

    void HideArrow()
    {
        arrow.SetActive(false);
    }


}
