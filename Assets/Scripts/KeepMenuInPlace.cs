using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMenuInPlace : MonoBehaviour
{
    float posZ;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float height = (Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * 0.5f) * posZ * 2f) / 10f;
        float width = height * cam.aspect;
    }
}
