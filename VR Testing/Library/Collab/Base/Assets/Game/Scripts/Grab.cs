using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    bool isHolding = false;
    List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (OVRInput.Get(OVRInput.RawButton.LHandTrigger) && !isHolding)
        {
            isHolding = true;
            foreach (GameObject go in objects)
            {
                go.transform.parent = transform;
                if (go.GetComponent<Rigidbody>())
                {
                    Rigidbody rb = go.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }
            }
        }
        else if(!OVRInput.Get(OVRInput.RawButton.LHandTrigger) && isHolding)
        {
            foreach (GameObject go in objects)
            {
                if (go.GetComponent<Rigidbody>())
                {
                    Rigidbody rb = go.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.velocity = OVRInput.GetLocalControllerVeclotiy(OVRInput.Controller.LTouch);
                }
            }
            transform.DetatchChildren();
        }

    }
    void OnTriggerEnter(Collider col)
    {
        objects.Add(col.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        objects.Remove(col.gameObject);
    }
}
