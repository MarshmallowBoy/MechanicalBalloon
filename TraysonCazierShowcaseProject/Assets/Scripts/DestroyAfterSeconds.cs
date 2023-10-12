using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float Seconds;
    private void Awake()
    {
        Invoke("DestroyMe", Seconds);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
