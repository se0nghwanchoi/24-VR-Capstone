using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyUI : MonoBehaviour
{
    public GameObject emergencyUI;  // Ȱ��ȭ�� UI ������Ʈ�� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emergencyUI.SetActive(true);  // UI ������Ʈ Ȱ��ȭ
            Debug.Log("���� UI ����");
            StartCoroutine(DeactivateAfterTime(8));  // 8�� �� ������Ʈ ��Ȱ��ȭ
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emergencyUI.SetActive(false);  // ������Ʈ ��Ȱ��ȭ
        Debug.Log("���� UI ��Ȱ��ȭ");
    }
}