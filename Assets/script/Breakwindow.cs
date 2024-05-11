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
  
    public AudioClip emergencySound; // ��� �Ҹ� ����� Ŭ��
    private AudioSource audioSource; // AudioSource ������Ʈ

    void Start()
    {
        // AudioSource ������Ʈ�� ���� ������Ʈ�� �߰��ϰ� �����մϴ�.
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // �Ҹ��� �ݺ� ����ϵ��� ���� [�����: ���� �ݺ� ����� ���� loop �Ӽ��� true�� ����]
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
        Destroy(window);
        // ��ƼŬ ����
        Transform particleInstance = Instantiate(destroyEffectPrefab, createPoint.position, createPoint.rotation, createPoint);
       

        // ��� �Ҹ� ���
        if (emergencySound != null && !audioSource.isPlaying) // [�����: audioSource.isPlaying�� üũ�Ͽ� �̹� ��� ���� �Ҹ��� �ߺ� ������� �ʵ��� ��]
        {
            audioSource.clip = emergencySound;
            audioSource.Play();
        }
    }
}