using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyUI : MonoBehaviour
{
    public GameObject emergencyUI;  // 활성화할 UI 오브젝트의 참조

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emergencyUI.SetActive(true);  // UI 오브젝트 활성화
            Debug.Log("대피 UI 생성");
            StartCoroutine(DeactivateAfterTime(8));  // 8초 후 오브젝트 비활성화
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emergencyUI.SetActive(false);  // 오브젝트 비활성화
        Debug.Log("대피 UI 비활성화");
    }
}