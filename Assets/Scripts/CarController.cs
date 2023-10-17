using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelColider;
        public Axel wheelAxel;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public List<Wheel> wheels;

    float moveInput;

    private Rigidbody carRb;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInputs();
    }

    void LateUpdate()
    {
        Move();
    }

    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
    }

    void Move ()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelColider.motorTorque = moveInput * maxAcceleration * Time.deltaTime;
        }
    }
}
