using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTransform : MonoBehaviour
{
    public Transform t;
    public Vector3 correct;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(t, correct);
    }
}
