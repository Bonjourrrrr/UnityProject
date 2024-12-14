using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotsMovements : MonoBehaviour
{
    public float rotationSpeed = 50; // rotation speed of the carrots 

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // rotate the carrots around the y-axis
    }
}
