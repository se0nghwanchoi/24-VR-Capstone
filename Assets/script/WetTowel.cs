using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTowel : MonoBehaviour
{
    
    public Material blueMaterial; // �Ķ��� ��Ƽ������ ������ public ���� �߰�
   
    

    void Start()
    {
        
    }

    // Ʈ���ŷ� �浹�� ���۵Ǿ��� �� ȣ���
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� �±װ� "Water"�� ��쿡�� ó��
        if (other.CompareTag("Water"))
        {
            // ����� �α� ���
            Debug.Log("���� �浹�߽��ϴ�!");

            // ������ ��Ƽ������ �Ķ������� ����
            GetComponent<Renderer>().material = blueMaterial;

                      
        }
    }

   

}
