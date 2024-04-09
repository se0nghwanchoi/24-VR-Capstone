using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterSpawn : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // ������ XRInteractable
    public GameObject WaterPrefab; // GameObject�� ����
    public Transform WaterPoint;

    private GameObject currentWaterInstance; // ���� ������ WaterPrefab �ν��Ͻ��� ����

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
        if (currentWaterInstance == null) // ���� �ν��Ͻ��� ���� ���� ����
        {
            // WaterPrefab �ν��Ͻ� ����
            currentWaterInstance = Instantiate(WaterPrefab, WaterPoint.position, WaterPoint.rotation);
        }
        else // �̹� �ν��Ͻ��� ���� ��� �ν��Ͻ� ����
        {
            Destroy(currentWaterInstance);
            currentWaterInstance = null;
        }
    }
}
