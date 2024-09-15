using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTransform : MonoBehaviour
{
    public Transform t;
    public Vector3 correct;

    public int v = 0;

    private void Start()
    {
       // t.Rotate(0, 90, 0);
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 relativePos = t.position - transform.position;
        Vector3 fxu = Vector3.Cross(relativePos, Vector3.up);
        Vector3 zx = Vector3.Cross(relativePos, fxu);

        // the second argument, upwards, defaults to Vector3.up
        if (v == 0)
        {
            Quaternion rotation = Quaternion.LookRotation(zx, Vector3.up);
            transform.rotation = rotation;
        }

        if (v == 1)
        {
            Quaternion rotation = Quaternion.LookRotation(fxu, Vector3.up);
            transform.rotation = rotation;
        }

        if (v == 2)
        {
            Quaternion rotation = Quaternion.LookRotation(zx, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
