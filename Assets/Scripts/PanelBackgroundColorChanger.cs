using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBackgroundColorChanger : MonoBehaviour
{
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time % 1.0f;
        Color color = gradient.Evaluate(time);
        GetComponent<CanvasRenderer>().SetColor(color);
    }
}
