using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDmanager : MonoBehaviour
{
    public static IDmanager Instance { get; private set; }
    public string StudentID;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this){
            Destroy(gameObject);
        }
    }
}
