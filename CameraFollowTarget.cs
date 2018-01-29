using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{

    public GameObject target;
    public Vector3 offset;
    public float smooth;


    private void FixedUpdate()
    {
        Vector3 desired = target.transform.position + offset;
        Vector3 current = transform.position;
        Vector3 smoothedposition = Vector3.Lerp(current, desired, smooth);
        transform.position = smoothedposition;
    }
}
