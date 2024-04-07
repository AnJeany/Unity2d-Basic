using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    [SerializeField] private int speed;
    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 cameraOffsetVector;


    private void Start()
    {
        cameraOffsetVector = Camera.main.transform.position - transform.position;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.Translate (Vector3.forward * speed * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
        }
        Camera.main.transform.position = transform.position + cameraOffsetVector;
    }

    enum DriveMode
    {
        Manual,
        Automic,
    }

}