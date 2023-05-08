using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraChanger : MonoBehaviour
{

    public List<Camera> cameras = new List<Camera>();
    private int activeCamera = 0;
    public List<PlayerMove> players = new List<PlayerMove>();
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Camera[] foundCamera = FindObjectsOfType<Camera>();
        foundCamera = foundCamera.OrderBy(camera => camera.gameObject.name).ToArray();
        cameras.AddRange(foundCamera);
        PlayerMove[] playerObjects = FindObjectsOfType<PlayerMove>();
        players.AddRange(playerObjects);
        player = players[0].gameObject;

        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].name != "Camera1")
            {
                cameras[i].gameObject.SetActive(false);
            } else {
                cameras[i].gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameras[activeCamera].gameObject.SetActive(false);
            activeCamera++;
            if (activeCamera >= cameras.Count)
            {
                activeCamera = 0;
            }

            cameras[activeCamera].gameObject.SetActive(true);
        }
    }

    void LateUpdate()
    {
        if (cameras[activeCamera].name == "Camera4"){
            for (int i = 0; i < players.Count; i++){
                if (players[i].enabled)
                {
                    player = players[i].gameObject;
                }
            }
            
            Vector3 targetPosition = player.transform.position;
            cameras[3].transform.position = Vector3.Lerp(cameras[3].transform.position, 
            new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z - 20), 
            1);
        }
    }
}
