using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Climbers : MonoBehaviour
{
    public float wallClimbingSpeed = 2.0f;
    public float wallJumpSpeed = 5.0f;
    private bool isClimbingWall = false;
    private CharacterController controller;
    public float speed = 5f;
    public float jumpSpeed = 5f;

    private void Start()
    {
        controller= GetComponent<CharacterController>();
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y < 0.1f)
        {
            Debug.Log("Touched Wall");
            isClimbingWall = true;
        }
    }
    void WallClimbing()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        movement = transform.TransformDirection(movement);

        movement *= wallClimbingSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumps Jumps");
            movement.y = wallJumpSpeed;
            isClimbingWall = false;
        }

        controller.Move(movement * Time.deltaTime);
    }

    void RegularMovement()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
        movement = transform.TransformDirection(movement);

        movement *= speed;

        if (Input.GetButtonDown("Jump"))
        {
            movement.y = jumpSpeed;
        }

        controller.Move(movement * Time.deltaTime);
    }

    void Update()
    {
        if (isClimbingWall)
        {
            WallClimbing();
        }
        else
        {
            RegularMovement();
        }
    }
}
