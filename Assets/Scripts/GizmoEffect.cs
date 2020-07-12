using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoEffect : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField]Vector3 siz = new Vector3();

    float width;
    private void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
        //Gizmos.DrawCube(transform.position, siz);
        //width = transform.parent.transform.localScale.x;
        //Gizmos.DrawCube(transform.position, new Vector3(width/2, 0.01f, 1f));
    }
}
