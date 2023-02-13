using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    
    void Update()
    {
        float x = Input.GetAxis("Horziontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * transform.forward * z;

        controller.Mpove(move * speed * Time.deltaTime);
    }
}
