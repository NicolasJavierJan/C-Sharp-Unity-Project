using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerScript : MonoBehaviour
{
    public List<PlayerMove> players = new List<PlayerMove>();
    private int activePlayer = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove[] playerObjects = FindObjectsOfType<PlayerMove>();
        players.AddRange(playerObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            DeactivatePlayer(activePlayer);
            activePlayer++;
            
            if (activePlayer >= players.Count)
            {
                activePlayer = 0;
            }

            ActivatePlayer(activePlayer);
        }
    }

    private void DeactivatePlayer(int index)
    {
        players[index].enabled = false;
    }

    private void ActivatePlayer(int index)
    {
        players[index].enabled = true;
    }
}
