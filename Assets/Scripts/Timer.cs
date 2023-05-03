using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text timer;
    public float time;
    public Goal goalFor;
    public Goal goalAgainst;
    public Kick kickScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goalFor.goalMade == false && kickScript.outOfBounds == false && goalAgainst.goalMade == false)
        {
            time += Time.deltaTime;
            timer.text = time.ToString("F2");
        } 
    }
}
