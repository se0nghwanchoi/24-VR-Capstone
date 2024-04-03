using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
   public class LoginManager : MonoBehaviour
    {
        public void SceneChange()
        {
            SceneManager.LoadScene("Initial_start_Menu");
        }
    }


