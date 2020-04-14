using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    //Time.deltaTime makes smoothing framerate indipendant 
    public float smoothing = 2.0f;
    // the chacter is the tube 
    public Transform player;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    private float xRotation = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        //use the mouse to determine x and y
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * smoothing;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * smoothing;

        // the interpolated float result between float values
        xRotation = Mathf.Lerp(xRotation, mouseY, 1f / smoothing);
        // incrementally add this to the camera look
        mouseLook.y -= xRotation;
        //do not allow mouseLook.y to exceed -90 to 90 degrees
        if(mouseLook.y > 90){
            mouseLook.y = 90;
        }
         if(mouseLook.y < -90){
            mouseLook.y = -90;
        }

        // vector3.right means the x-axis
        //the transform is for the camera the script is attached to
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        //this rotates the chatracter (and the camera) left + right
        player.Rotate(Vector3.up * mouseX);
    }

    
}
