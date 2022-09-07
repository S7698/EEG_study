using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Move : MonoBehaviour
{
    
    // camera should follow player = target
    [SerializeField]
    private Transform target;

    // go directly in update function and start would not be needed
    // public Vector3 offset = Vector3(0, 1, -10);
    // or:
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // every time you move the camera 
        // it automatically creates this offset and you only have to move the camera
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    // runs after the player update (second loop) to make it smooth
    
    void LateUpdate()
    {
        // include null check (if dead etc.)
        if (target != null)
        {
            // need offset so that they are not both at the same position
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.))
        {
            Application.Quit();
        }

    }
    
}
