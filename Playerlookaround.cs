using UnityEngine;

public class Playerlookaround : MonoBehaviour
{   

    // Code for Mouse Look:
    [SerializeField] Transform cam;
    [SerializeField] float sensitivity;
    float headRotation = 0f;

    // Code for limiting rotation at x and y axis:
    [SerializeField] float headRotationLimit = 90f;

    void Start()
    {
        // Code to hide cursor when playing:
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  
    }

   
    void Update()
    {
        // Code for Mouse Look:
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;

        transform.Rotate(0f, x, 0f);

        headRotation += y;
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);

        // Code for limiting rotation at x and y axis:
        headRotation += y;
        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);

    }
}
