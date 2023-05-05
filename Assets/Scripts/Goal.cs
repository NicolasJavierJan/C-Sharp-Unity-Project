using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

        public TMP_Text goal;
        public bool goalMade = false;
        public CameraScript cameraScript;
        public Kick kickScript;

    // Start is called before the first frame update
    void Start()
    {
        goal.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider ball)
    {
        if (ball.CompareTag("Ball"))
        {
            GameObject goalPost = gameObject;
            if (goalPost.CompareTag("LocalPost"))
            {
                GetComponent<AudioSource>().Play();
                goal.text = "GOAL AGAINST =(";
                goalMade = true;
                kickScript.enabled = false;
                StartCoroutine(WaitSomeTime());
                cameraScript.enabled = false;
            } else {
                GetComponent<AudioSource>().Play();
                goal.text = "GOAL";
                goalMade = true;
                kickScript.enabled = false;
                StartCoroutine(WaitSomeTime());
                cameraScript.enabled = false;
            }            
        }
    }

    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(4);
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }
}
