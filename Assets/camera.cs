using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{

    // Camera mycam;

    public float mouseSensitivity = 100f;

    public Transform playerbody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //mycam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        //transform.rotation = Quaternion.Euler(0f, 5f, 0f); 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 

        playerbody.Rotate(Vector3.up * mouseX);

    }
}
