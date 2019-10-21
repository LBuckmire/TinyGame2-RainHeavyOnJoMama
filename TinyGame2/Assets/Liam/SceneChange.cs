using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    

   public void OnMouseClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        //Application.LoadLevel(SceneName);
    }
}
