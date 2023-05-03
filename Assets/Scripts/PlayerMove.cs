using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Character
    public CharacterController character;
    // Transformer (for rotating)
    public Transform transformer;
    // Speeds
    public float moveMaxPerSecond = 24;
    public float moveTimeToMax = .26f;
    public float moveTimeToZero = .2f;
    public float moveReverseMomentum = 2.2f;

    private Vector3 _movement = Vector3.zero;

    // Getting the Plane to bound the character inside.
    private MeshRenderer plane;
    private Bounds planeBounds;

    // Derived velocity gain per second
    public float MoveVelocityGain
    {
        get => moveMaxPerSecond / moveTimeToMax;
    }

    // Derived velocity loss per second
    public float MoveVelocityLoss
    {
        get => moveMaxPerSecond / moveTimeToZero;
    }

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Ground").GetComponent<MeshRenderer>();
        planeBounds = plane.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, planeBounds.min.x, planeBounds.max.x);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, planeBounds.min.z, planeBounds.max.z);
        transform.position = clampedPosition;
    }

    void Movement() {
        // Sorting the Z dimension first..
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (_movement.z >= 0)
            {
                // Forwards
                _movement.z += MoveVelocityGain * Time.deltaTime;
                _movement.z = Mathf.Min(moveMaxPerSecond, _movement.z);
            }
            else
            {
                // Reverse forwards
                _movement.z += MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.z = Mathf.Min(0, _movement.z);
            }
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (_movement.z <= 0)
            {
                // Backwards
                _movement.z -= MoveVelocityGain * Time.deltaTime;
                _movement.z = Mathf.Max(-moveMaxPerSecond, _movement.z);
            }
            else
            {
                // Reverse backwards
                _movement.z -= MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.z = Mathf.Max(0, _movement.z);
            }
        }
        else
        {
            // Slow down 
            if (_movement.z > 0)
            {
                // From forwards
                _movement.z -= MoveVelocityLoss * Time.deltaTime;
                _movement.z = Mathf.Max(0, _movement.z);
            }
            else if (_movement.z < 0)
            {
                // From backwards
                _movement.z += MoveVelocityLoss * Time.deltaTime;
                _movement.z = Mathf.Min(0, _movement.z);
            }

        }

        
        // Same as above, but in the left/right of the X dimension
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (_movement.x >= 0)
            {
                // Right
                _movement.x += MoveVelocityGain * Time.deltaTime;
                _movement.x = Mathf.Min(moveMaxPerSecond, _movement.x);
            }
            else
            {
                // Reverse right
                _movement.x += MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.x = Mathf.Min(0, _movement.x);
            }

        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (_movement.x <= 0)
            {
                // Left
                _movement.x -= MoveVelocityGain * Time.deltaTime;
                _movement.x = Mathf.Max(-moveMaxPerSecond, _movement.x);
            }
            else
            {
                // Break left
                _movement.x -= MoveVelocityGain * moveReverseMomentum * Time.deltaTime;
                //_movement.x = Mathf.Max(0, _movement.x);
            }
        }
        else
        {
            // Slow down 
            if (_movement.x > 0)
            {
                // From right
                _movement.x -= MoveVelocityLoss * Time.deltaTime;
                _movement.x = Mathf.Max(0, _movement.x);
            }
            else if (_movement.x < 0)
            {
                // From left
                _movement.x += MoveVelocityLoss * Time.deltaTime;
                _movement.x = Mathf.Min(0, _movement.x);
            }
            
        }

        // No need to move the character controller if no movement registered.
        if (_movement.z != 0 || _movement.x != 0)
        {
            character.Move(_movement * Time.deltaTime);
            if (transformer is not null)
            {
                var toLookRotation = Quaternion.LookRotation(_movement);
                //transformer.rotation = toLookRotation;
                // Slerp in a slow way from having one rotation to a target rotation
                transformer.rotation = Quaternion.Slerp(transformer.rotation, toLookRotation, .1f);
                
            }            
        }
    }
}
