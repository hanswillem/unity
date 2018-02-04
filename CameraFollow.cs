using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public GameObject target;
    public Vector3 offset;
    public bool camshake;
    public float camshakesize;
    private float camshakesizeinternal;
    public float camshakedamping;


    private void Start()
    {
        camshakesizeinternal = camshakesize;
    }


    private void Update()
    {
        if (camshake)
        {
            Vector3 shake = Random.insideUnitSphere * camshakesizeinternal;
            transform.position = target.transform.position + offset + shake;
            if (camshakesizeinternal > 0)
                camshakesizeinternal -= camshakedamping;
            else
            {
                camshake = false;
                camshakesizeinternal = camshakesize;
            }
        }
        else
            transform.position = target.transform.position + offset;
    }


    public void ShakeIt()
    {
        camshake = true;
    }
}
