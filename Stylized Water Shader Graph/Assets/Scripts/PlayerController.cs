using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;

//this script is by the help of the tutoring video on Youtube https://www.youtube.com/watch?v=4HpC--2iowE&list=PLxIslHWUz_SYXQrcfj5J2QPnoApDC_urx&index=9&t=946s
//I revised both the moving and rotation part based on my need of game
public class PlayerController : MonoBehaviour
{
    public CharacterController controller; //reference to the character controller compoment in Unity
    public float speed = 6f;
    public float turnSmoothTime = 0.01f; //the value to be multiple to reduce the sharpness of the rotation movement
    float turnSmoothVelocity; //reference to hold the current velocity

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //get the raw axis to avoid smoothness
        //value in the internal [-1, 1]; press left = -1; press right = 1
        float vertical = Input.GetAxisRaw("Vertical");
        // value in the internal [-1, 1]; press up = 1; press down = -1
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        //set up direction for the moving, this game is top-down RTS, so the player won't move on y-axis, set as 0f
        //to set it won't go diagonally when hold 2 keys (combined direction), normolize this vector!

        if (moveDirection.magnitude >= 0.1f) //the condition to get inputs to move when length of the vector is > than 1
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            //calculate the rotation angle (specific way in unity which from 0 degree on y-axis and change clockwise)
            //switch radians to degree by using mathf.rad2deg

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //way to smooth angles in Unity

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //only rotate through y-axis; use angle rather than targetangle to let rotation smooth

            controller.Move(moveDirection * speed * Time.deltaTime);

            ///
        }
    }
}

