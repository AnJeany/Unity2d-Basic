using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarMover : MonoBehaviour
{

    [SerializeField] private int speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.position += transform.forward * horizontalInput * speed * Time.deltaTime;

        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.position += transform.right * verticalInput * speed * Time.deltaTime;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}
    }

    [Serializable]
    public class Character
    {
        [SerializeField] private int maxSpeed;
        [SerializeField] private int attackValue;
        [SerializeField] private Weapon currenWeapon;
    }


    private void Jump()
    {
        rb.AddForce(Vector3.up * speed);
    }
    [Serializable]
    public class Weapon
    {
        public float AttackValue;
        [SerializeField] private float attackValue;
    }
}
