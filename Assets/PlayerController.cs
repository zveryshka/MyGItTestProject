using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CharacterController characterController;

    float y = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (characterController.isGrounded)
        {
           if(y < 0) y = -2f;
           if(Input.GetKeyDown(KeyCode.Space))
            {
                y = 5f;
            }
        }

        y += 9.81f * Time.deltaTime;
        move.y = y;

        characterController.Move(move * Time.deltaTime);
    }
}
