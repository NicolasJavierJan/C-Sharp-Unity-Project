using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainController : MonoBehaviour
{
    public Button Level2;
    public Button Level3;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PlayerPrefs.GetInt("Level") == 2)
            {
                GameObject buttonLevel2 = GameObject.Find("PlayLevel02Button");
                Level2 = buttonLevel2.GetComponent<Button>();
                Level2.interactable = true;
            } else if (PlayerPrefs.GetInt("Level") == 3)
            {
                GameObject buttonLevel2 = GameObject.Find("PlayLevel02Button");
                Level2 = buttonLevel2.GetComponent<Button>();
                Level2.interactable = true;
                GameObject buttonLevel3 = GameObject.Find("PlayLevel03Button");
                Level2 = buttonLevel3.GetComponent<Button>();
                Level2.interactable = true;
            }
            
        }
        
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
        PlayerPrefs.DeleteKey("Level");

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

    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(3);
    }
}
