using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_scenes : MonoBehaviour
{
    // Start is called before the first frame update

    public class SceneLoader : MonoBehaviour
    {
        public void SceneChange()
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }


}
