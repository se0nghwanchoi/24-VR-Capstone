using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangetoTyphoon : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeTyphoonsceneBtn()
    {
        SceneManager.LoadScene("Typhoon_Scene");
    }
}
