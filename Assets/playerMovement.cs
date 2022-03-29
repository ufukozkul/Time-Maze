using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMovement : MonoBehaviour
{

    public CharacterController contoller;
    public float speed = 12f;
    public float gravity = -9.81f;

    public float jumpHeight = 4f;
    Vector3 velocity;
    public Transform groundCheck;
    float groundDistance = 0.5f;
    public LayerMask groundMask;
    bool isGround;

    public LayerMask start;
    public LayerMask finish;
    bool isStarted = false;
    bool isFinished = false;
    public float timer = 0;

    public Text timerUI;
    public Text completed;


    // Update is called once per frame
    void Update()
    {

        UpdateUI();
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(Physics.CheckSphere(groundCheck.position, groundDistance, start))
        {
            isStarted = true;
        }

        if (isStarted)
        {
            timer += Time.deltaTime;
        }

        if(Physics.CheckSphere(groundCheck.position, groundDistance, finish))
        {
            //finished
            isStarted = false;
            Time.timeScale = 0.0f;
            completed.text = "Maze Completed: " + timer.ToString();
        }

        if (isGround && velocity.y <= 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = jumpHeight;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        contoller.Move(move * speed * Time.deltaTime);

        
        contoller.Move(velocity * Time.deltaTime);


    }

    public void UpdateUI()
    {
        timerUI.text = timer.ToString();

    }
}
