using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class IDLogin : MonoBehaviour
{
    public InputField studentID_Field;
    public string url = "http://localhost/Capstone24/CreateID.php";

    public void ServerLogin()
    {
        string studentID = studentID_Field.text;
        IDmanager.Instance.StudentID = studentID;

        StartCoroutine(CreateID(studentID));
    }

    IEnumerator CreateID(string studentID)
    {
        WWWForm form = new WWWForm();
        form.AddField("ID", studentID);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                Debug.Log("ID record: " + studentID);
            }
        }
    }
}
