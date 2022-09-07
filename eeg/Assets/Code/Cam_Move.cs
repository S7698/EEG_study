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

    // new
    float smooth = 5.0f;
    float tiltAngle = 6.0f;

    // Start is called before the first frame update

    void Start()
    {
        // every time you move the camera 
        // it automatically creates this offset and you only have to move the camera
        offset = transform.position - target.transform.position;
    }

    
    //new
    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
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

        

    }
    
}
