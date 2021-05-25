using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGravityHandler : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().Sleep();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.forward * 30;
        Gizmos.DrawRay(transform.position, direction);
    }
}
