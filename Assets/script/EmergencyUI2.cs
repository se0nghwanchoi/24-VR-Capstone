using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyUI2 : MonoBehaviour
{
    public GameObject emergencyUI2;  // 활성화할 UI 오브젝트의 참조

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emergencyUI2.SetActive(true);  // UI 오브젝트 활성화
            Debug.Log("화재시 잘못된 문 열면 생기는 경고 UI 생성");
            StartCoroutine(DeactivateAfterTime(8));  // 8초 후 오브젝트 비활성화
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emergencyUI2.SetActive(false);  // 오브젝트 비활성화
        Debug.Log("화재시 잘못된 문 열면 생기는 경고 UI 비활성화");
    }
}