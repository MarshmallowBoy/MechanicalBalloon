using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMousePosition : MonoBehaviour
{
    public float Distance = 1;
    void Update()
    {
        
        transform.position = SimulateCameraToWorldAtPosition(Vector3.zero) * Distance;
    }

    Vector3 SimulateCameraToWorldAtPosition(Vector3 offsetPosition)
    {
        Vector3Int ScreenSize = new Vector3Int(Screen.currentResolution.width, Screen.currentResolution.height, 0);
        Vector3 newMousePos1 = Input.mousePosition - ScreenSize / 2;
        Vector3 newMousePos2 = newMousePos1 + offsetPosition;
        Vector3 newMousePos3 = new Vector3(newMousePos2.x / ScreenSize.x, newMousePos2.y / ScreenSize.y, 0) * 2;
        Vector3 newMousePos = new Vector3(newMousePos3.x * reduceFraction(ScreenSize.x, ScreenSize.y).x, newMousePos3.y * reduceFraction(ScreenSize.x, ScreenSize.y).y, 0);
        return newMousePos;
    }

    Vector3 reduceFraction(int x, int y)
    {
        int d;
        d = __gcd(x, y);

        x = x / d;
        y = y / d;
        return new Vector3(x, y, 0);
    }

    static int __gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return __gcd(b, a % b);

    }
}
