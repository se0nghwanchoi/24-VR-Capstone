using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDLogin : MonoBehaviour
{
    public InputField studentID_Field;

    public void ServerLogin()
    {
        string studentID = studentID_Field.text;
        IDmanager.Instance.StudentID = studentID;
    }
}
