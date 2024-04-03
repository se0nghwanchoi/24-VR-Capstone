using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class cshAnimManager : MonoBehaviour
{
    public Animator animFire;
    // Start is called before the first frame update
    void Start()
    {
        animFire.SetBool("Push_Btn_Reverse", true);
        animFire.SetBool("Open_Pin", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
