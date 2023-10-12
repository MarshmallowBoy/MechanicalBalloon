using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWhenStart : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
