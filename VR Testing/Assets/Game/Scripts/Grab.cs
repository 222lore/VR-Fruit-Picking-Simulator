using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    bool isHolding = false;
    List<GameObject> objects = new List<GameObject>();
    private Vector3 prevPos, currentPos;
    //public GameObject thisObj;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);

        if (OVRInput.Get(OVRInput.RawButton.LHandTrigger) && !isHolding)
        {
            isHolding = true;
            foreach (GameObject go in objects)
            {
                go.transform.parent = transform; // THIS OBJECT
                // IF NO WORK go.transform.SetParent(transform);
                // OR go.transform.SetParent(thisObj.transform);
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
                    rb.velocity = GetVelocity(Time.deltaTime);

                    go.transform.SetParent(null);
                }
            }
            //transform.DetatchChildren();
        }

        prevPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
    }
    void OnTriggerEnter(Collider col)
    {
        objects.Add(col.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        objects.Remove(col.gameObject);
    }

    Vector3 GetVelocity(float time)
    {
        float x = (currentPos.x - prevPos.x) / time;
        float y = (currentPos.y - prevPos.y) / time;
        float z = (currentPos.z - prevPos.z) / time;

        Vector3 velocity = new Vector3(x, y, z);
        return velocity;
    }
}
