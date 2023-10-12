using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransform : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;
    public Vector3 TransformVector;
    void LateUpdate()
    {
        if (x)
        {
            TransformVector = new Vector3(TransformVector.x, transform.position.y, transform.position.z);
        }
        if (y)
        {
            TransformVector = new Vector3(transform.position.x, TransformVector.y, transform.position.z);
        }
        if (z)
        {
            TransformVector = new Vector3(transform.position.x, transform.position.y, TransformVector.z);
        }
        transform.position = TransformVector;
    }
}
