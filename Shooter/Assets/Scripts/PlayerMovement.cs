using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public CharacterController controller;
    public float speed = 12f;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        // use a character controller to move your character with disregard to physics
        // character controller will be a component you add to your character ingame object
        controller.Move(move * speed * Time.deltaTime);
    }
}
