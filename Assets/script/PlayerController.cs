using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed;
    [SerializeField] private int speed;
    private Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 cameraOffsetVector;

    private float damaged = 0;
    private float fuel = 100;
    private float capacity = 100;
    private int laps;

    private bool canMove = true;



    private void Start()
    {
        cameraOffsetVector = Camera.main.transform.position - transform.position;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(FuelDecrease());
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //transform.position.z > 56 && transform.position.z < 64
        if (horizontalInput != 0 && canMove || verticalInput != 0 && canMove)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            damaged += 5;
            Debug.Log(damaged);
            if (damaged >= 100) 
            {
                Reset();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            fuel += 25;
        }
        Destroy(other.gameObject);
    }

    private void Reset()
    {
        SceneManager.LoadScene("Lesson 6");
    }

    private IEnumerator FuelDecrease()
    {
        yield return new WaitForSeconds(5);
        fuel = fuel - 15;
        Debug.Log(fuel);
    }



}
