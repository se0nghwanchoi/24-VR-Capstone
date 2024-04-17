using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyUI2 : MonoBehaviour
{
    public GameObject emergencyUI2;  // Ȱ��ȭ�� UI ������Ʈ�� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emergencyUI2.SetActive(true);  // UI ������Ʈ Ȱ��ȭ
            Debug.Log("ȭ��� �߸��� �� ���� ����� ��� UI ����");
            StartCoroutine(DeactivateAfterTime(8));  // 8�� �� ������Ʈ ��Ȱ��ȭ
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emergencyUI2.SetActive(false);  // ������Ʈ ��Ȱ��ȭ
        Debug.Log("ȭ��� �߸��� �� ���� ����� ��� UI ��Ȱ��ȭ");
    }
}