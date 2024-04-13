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
    private bool guidePlayed = false; // ���̵尡 ����Ǿ����� Ȯ���ϴ� ���� �߰�

    void Start()
    {
        open = false;
        audioSource =gameObject.AddComponent<AudioSource>(); // AudioSource ������Ʈ�� ������
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
        if (!open)
        {
            StartCoroutine(opening());
        }
        else
        {
            StartCoroutine(closing());
        }
    }

    IEnumerator opening()
    {
        openandclose.Play("Opening");
        open = true;

        // ó�� ���� ���� ���� �ȳ���۰� ȭ��ǥ�� Ȱ��ȭ�մϴ�.
        if (!guidePlayed)
        {
            audioSource.clip = broadcast;
            audioSource.Play();
            yield return new WaitForSeconds(broadcast.length); // ����� ����� ���� ������ ��ٸ�
            ShowArrow();
            guidePlayed = true; // ���̵� ��������� ǥ��
        }
        else
        {
            // �ȳ���۰� ȭ��ǥ�� �������� �ʽ��ϴ�.
            yield return null;
        }
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