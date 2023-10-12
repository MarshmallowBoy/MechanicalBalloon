using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetUIToPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        GetComponent<Toggle>().isOn = PlayerPrefs.GetInt("ControllerOverlay") > 0;
    }
}
