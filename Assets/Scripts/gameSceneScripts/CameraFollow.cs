using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class CameraFollow : MonoBehaviour
{
    // Distance in the x axis the target can move before the camera follows.
    public float xMargin = 1f;
    // Distance in the y axis the target can move before the camera follows.
    public float yMargin = 1f;
    // How smoothly the camera catches up with it's target movement in the x axis.
    public float xSmooth = 8f;
    // How smoothly the camera catches up with it's target movement in the y axis.
    public float ySmooth = 8f;
    // Reference to the target's transform.
    public Transform target;
    // Reference to the target's x postion.
    private float targetX;
    // Reference to the target's y postion.
    private float targetY;
    // Whether to follow the target's x position or not
    public bool followX = true;
    // Whether to follow the target's y position or not
    public bool followY = true;


    public Vector3 offsets;         //Follow position offsets;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private Vector2 cameraOffset;




    void Start()
    {



    }

    void Update()
    {
        TrackTarget();
    }

    void TrackTarget()
    {
        /*	if (target == null) {
                return;
            }

            // By default the target x and y coordinates of the camera are it's current x and y coordinates.
            targetX = transform.position.x;
            targetY = transform.position.y;

            if (followX) {
                // ... the target x coordinate should be a Lerp between the camera's current x position and the target's current x position.
                targetX = Mathf.Lerp (transform.position.x, target.position.x - xMargin, xSmooth * Time.deltaTime);
            }

            if (followY) {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the target's current y position.
                targetY = Mathf.Lerp (transform.position.y, target.position.y - yMargin, ySmooth * Time.deltaTime);
            }

            // Set the camera's position to the target position with the same z component.
            transform.position = new Vector3 (targetX, targetY, transform.position.z);
        }*/

        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0 , 5 , -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition-offsets, ref velocity, smoothTime);

        /*//Calculate desired follow position, depending on player's position and offsets;
        Vector2 followPos = new Vector3(target.position.x + offsets.x, offsets.y, offsets.z);
        //Assign follow position;

        transform.position = followPos;*/
    }





}
