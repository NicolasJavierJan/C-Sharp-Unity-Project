using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelBackgroundColorChanger : MonoBehaviour
{
    public Gradient gradient;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            Graphic panelImage = panel.GetComponent<Graphic>();
            Color newColor = new Color(0f, 0.6901f, 0.6784f, 1f);
            panelImage.color = newColor;

            if (!PlayerPrefs.HasKey("FunMode"))
            {
                PlayerPrefs.SetInt("FunMode", 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Graphic panelImage = panel.GetComponent<Graphic>();
        if (SceneManager.GetActiveScene().name != "MainScene")
        { 
            if (PlayerPrefs.GetInt("FunMode") == 0){
                Color newColor = new Color(1f, 1f, 1f, 0.0f);
                panelImage.color = newColor;
            } else {
                Color newColor = new Color(1f, 1f, 1f, 0.2f);
                panelImage.color = newColor;
                float time = Time.time % 1.0f;
                Color color = gradient.Evaluate(time);
                GetComponent<CanvasRenderer>().SetColor(color);
            }
        }
        else 
        {
            if (PlayerPrefs.GetInt("FunMode") == 1)
            {
                panelImage.color = Color.white;
                float time = Time.time % 1.0f;
                Color color = gradient.Evaluate(time);
                GetComponent<CanvasRenderer>().SetColor(color);
            } else {
                Color newColor = new Color(0f, 0.6901f, 0.6784f, 1f);
                panelImage.color = newColor;
            }
        }
        
    }
}
