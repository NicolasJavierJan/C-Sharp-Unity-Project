using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public TMP_Text timer;
    public Goal goalFor;
    public Goal goalAgainst;
    public Kick kickScript;
    public float timeLeft;
    public float totalTime;
    public int activeScene;
    public float timerDangerZone = 10f;
    public bool audioHasPlayed = false;


    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;

        if (activeScene == 1)
        {
            timeLeft = 30f;
            totalTime = timeLeft;
        } else if (activeScene == 2)
        {
            timeLeft = 60f;
            totalTime = timeLeft;
        } else {
            timeLeft = 90f;
            totalTime = timeLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goalFor.goalMade == false && kickScript.outOfBounds == false && goalAgainst.goalMade == false)
        {
            timeLeft = timeLeft - Time.deltaTime;
            timer.text = timeLeft.ToString("F2");
            if (timeLeft < totalTime / timerDangerZone && timeLeft > 0){
                timer.color = Color.red;
                if (!audioHasPlayed){
                    GetComponent<AudioSource>().Play();
                    audioHasPlayed = true;
                }
            }
        } else {
            if (goalFor.goalMade && timeLeft > 0)
            {
                if (activeScene == 1)
                {
                    // First check if a record already exists:
                    if (PlayerPrefs.HasKey("Level1Record")){
                        if (Mathf.RoundToInt(totalTime - timeLeft) < PlayerPrefs.GetInt("Level1Record")){
                            PlayerPrefs.SetInt("Level1Record", Mathf.RoundToInt(totalTime - timeLeft));
                        }
                    } else {
                        PlayerPrefs.SetInt("Level1Record", Mathf.RoundToInt(totalTime - timeLeft));
                    }
                } else if (activeScene == 2){
                        if (PlayerPrefs.HasKey("Level2Record")){
                            if (Mathf.RoundToInt(totalTime - timeLeft) < PlayerPrefs.GetInt("Level2Record")){
                                PlayerPrefs.SetInt("Level2Record", Mathf.RoundToInt(totalTime - timeLeft));
                            }
                    } else {
                        PlayerPrefs.SetInt("Level2Record", Mathf.RoundToInt(totalTime - timeLeft));
                    }
                } else if (activeScene == 3){
                    if (PlayerPrefs.HasKey("Level3Record")){
                        if (Mathf.RoundToInt(totalTime - timeLeft) < PlayerPrefs.GetInt("Level3Record")){
                            PlayerPrefs.SetInt("Level3Record", Mathf.RoundToInt(totalTime - timeLeft));
                        }
                    } else {
                        PlayerPrefs.SetInt("Level3Record", Mathf.RoundToInt(totalTime - timeLeft));
                    }
                }
            }
        }
    }
}
