using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class OpendoorGuide : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // 참조할 XR
    public Animator openandclose;
    public bool open;
    public GameObject arrow; // 화살표 객체
    public AudioClip broadcast; // 안내 방송 오디오 클립
    private AudioSource audioSource; // 오디오 소스 컴포넌트

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
        Invoke("ShowArrow", broadcast.length); // 방송 길이 후 화살표 표시
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
        Invoke("HideArrow", 20); // 20초 후 화살표 숨김
    }

    void HideArrow()
    {
        arrow.SetActive(false);
    }


}
