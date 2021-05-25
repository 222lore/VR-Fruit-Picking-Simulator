using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRController : MonoBehaviour
{
    [Header("VR Controls Settings")]
    public bool forcedMovement = false;
    public bool forcedScenes = false;
    public bool forcedJump = true;
    public const float WALK_SPEED = 2.5f, JUMP_VARIABLE = 7.0f;
    public GameObject camera;
    public Rigidbody player;

    // Start is called before the first frame update
    void Start() 
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        // Move character
        if (forcedMovement) 
        {
            Move();
        }

        // Check if need to cange scenes
        if (forcedScenes)
        {
            ManageScene();
        }
        
        // Jump if x is pressed
        if (forcedJump && OVRInput.Get(OVRInput.RawButton.X))
        {
            StartCoroutine(EnableJump());
        }
    }

    // Move player using joystick
    void Move()
    {
        // Camera/player movement with the left joystick
        Vector2 movementInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 movement = camera.transform.TransformDirection(movementInput.x, 0, movementInput.y);
        movement.y = 0;
        movement = movement.magnitude == 0 ? Vector3.zero : movement / movement.magnitude;
        movement *= Time.deltaTime * WALK_SPEED;
        this.transform.Translate(movement);
    }

    // Changes the scene
    void ManageScene()
    {
        // Loads next scene
        if (OVRInput.Get(OVRInput.RawButton.A)) // A
        {
            try
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            catch (Exception e) {}
        }

        // Loads previous scene
        if (OVRInput.Get(OVRInput.RawButton.B)) // B
        {
            try
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            catch (Exception e) {}
        }
    }

    // Jump Method
    IEnumerator EnableJump() 
    {
        player.useGravity = false;
        player.AddForce(Vector3.up * -9.81f, ForceMode.Acceleration);
        yield return new WaitForSeconds(3.0f);
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
        player.useGravity = true;
    }
}
