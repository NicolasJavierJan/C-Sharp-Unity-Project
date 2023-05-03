using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{

    public Rigidbody rigidBody; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
            if (player is not null)
            {
                // By subtracting the two vectors, we get a delta that 
                // 'points' from player towards this object, basically
                // The direction we need to move forwards
                var deltaPosition = rigidBody.transform.position - player.character.transform.position;
                
                // Make sure y is flattened since we do not
                // move up or down
                deltaPosition.y = 0;
                
                // Make it a unit direction (magnitude of 1)
                var forward = deltaPosition.normalized;

                // Add an impulse forward, using the speed of the player
                rigidBody.AddForce(forward * 20.0f, ForceMode.Impulse);
                
            }
        }
    }

    
}
