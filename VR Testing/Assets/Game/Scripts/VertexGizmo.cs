using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexGizmo : MonoBehaviour
{
    public float gizmoSize = 0.75f;
    public Color gizmoColour = Color.yellow;
    
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
