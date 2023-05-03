using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PlayerPrefs.DeleteKey("FunMode");
            SceneManager.LoadScene(0);
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            PlayerPrefs.DeleteKey("FunMode");
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            PlayerPrefs.DeleteKey("FunMode");
            Application.Quit();
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
}
