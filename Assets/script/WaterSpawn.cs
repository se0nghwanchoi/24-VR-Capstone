using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterSpawn : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // 참조할 XRInteractable
    public GameObject WaterPrefab; // GameObject로 변경
    public Transform WaterPoint;

    private GameObject currentWaterInstance; // 현재 생성된 WaterPrefab 인스턴스의 참조

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
        if (currentWaterInstance == null) // 현재 인스턴스가 없을 때만 생성
        {
            // WaterPrefab 인스턴스 생성
            currentWaterInstance = Instantiate(WaterPrefab, WaterPoint.position, WaterPoint.rotation);
        }
        else // 이미 인스턴스가 있을 경우 인스턴스 제거
        {
            Destroy(currentWaterInstance);
            currentWaterInstance = null;
        }
    }
}
