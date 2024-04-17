using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyUI : MonoBehaviour
{
    public GameObject emergencyUI;  // Ȱ��ȭ�� UI ������Ʈ�� ����
    private bool hasActivated = false;  // UI�� �̹� Ȱ��ȭ �Ǿ����� Ȯ���ϴ� �÷���

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ �ݶ��̴��� ������, UI�� ���� Ȱ��ȭ���� �ʾҴٸ�
        if (other.CompareTag("Player") && !hasActivated)
        {
            emergencyUI.SetActive(true);  // UI ������Ʈ Ȱ��ȭ
            Debug.Log("���� UI ����");
            StartCoroutine(DeactivateAfterTime(8));  // 8�� �� ������Ʈ ��Ȱ��ȭ
            hasActivated = true;  // Ȱ��ȭ �÷��׸� true�� ����
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emergencyUI.SetActive(false);  // ������Ʈ ��Ȱ��ȭ
        Debug.Log("���� UI ��Ȱ��ȭ");
    }
}