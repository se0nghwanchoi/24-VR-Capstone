using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� �߰�

public class FireWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText; // ��� �ؽ�Ʈ�� ���� ����
    public float displayTime = 5.0f; // �ؽ�Ʈ�� ǥ���� �ð� (��)

    void Start()
    {
        warningText.gameObject.SetActive(false); // ���� �� ��� �ؽ�Ʈ�� ����ϴ�.
        ShowWarning(); // ��� �޽����� ǥ���ϴ� �Լ� ȣ��
    }

    public void ShowWarning()
    {
        warningText.gameObject.SetActive(true); // ��� �ؽ�Ʈ�� Ȱ��ȭ�մϴ�.
        Invoke("HideWarning", displayTime); // displayTime �Ŀ� HideWarning �Լ� ȣ��
    }

    void HideWarning()
    {
        warningText.gameObject.SetActive(false); // ��� �ؽ�Ʈ�� ��Ȱ��ȭ�մϴ�.
    }
}
