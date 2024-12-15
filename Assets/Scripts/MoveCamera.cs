using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        if (transform != null && cameraPosition != null) // if the camera and cameraPosition are not null, move the camera to the cameraPosition
        {
            transform.position = cameraPosition.position;
        }
    }
}
