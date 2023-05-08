using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainController : MonoBehaviour
{
    public Button Level2;
    public Button Level3;

    public TMP_Text levelone;
    public TMP_Text leveltwo;
    public TMP_Text levelthree;

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
            if (PlayerPrefs.HasKey("Level1Record")){
                GameObject levelOneRecord = GameObject.Find("BestTime1");
                levelone = levelOneRecord.GetComponent<TMP_Text>();
                levelone.text = "Level 1: " + PlayerPrefs.GetInt("Level1Record").ToString("F2");
            }
            if (PlayerPrefs.HasKey("Level2Record")){
                GameObject levelTwoRecord = GameObject.Find("BestTime2");
                leveltwo = levelTwoRecord.GetComponent<TMP_Text>();
                leveltwo.text = "Level 2: " + PlayerPrefs.GetInt("Level2Record").ToString("F2");
            }
            if (PlayerPrefs.HasKey("Level3Record")){
                GameObject levelThreeRecord = GameObject.Find("BestTime3");
                levelthree = levelThreeRecord.GetComponent<TMP_Text>();
                levelthree.text = "Level 3: " + PlayerPrefs.GetInt("Level3Record").ToString("F2");
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
        PlayerPrefs.DeleteKey("Level1Record");
        PlayerPrefs.DeleteKey("Level2Record");
        PlayerPrefs.DeleteKey("Level3Record");

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
