using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangetoEQ : MonoBehaviour
{
    public void ChangeEarthquakesceneBtn()
    {
        SceneManager.LoadScene("Earthquake_Scene");
    }
}
