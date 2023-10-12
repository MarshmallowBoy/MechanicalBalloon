using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
    public GameObject[] Buttons;
    int Index = 0;
    public GameObject toggleMenu;
    public bool Toggled;
    public bool CanUseSystem = false;
    public GameObject ControllerImage;
    public bool UsingControllerSelect = false;
    public UIFunctions turnOffControllerSelectOnStart;
    public GameObject settingsMenu;

    private void OnEnable()
    {
        CanUseSystem = false;
        Invoke("UseSystem", 1);
        if (turnOffControllerSelectOnStart != null)
        {
            turnOffControllerSelectOnStart.enabled = false;
        }
    }

    private void OnDisable()
    {
        if (turnOffControllerSelectOnStart != null)
        {
            turnOffControllerSelectOnStart.enabled = true;
        }
    }
    void UseSystem()
    {
        CanUseSystem = true;
    }
    public void Update()
    {
        if (ControllerImage != null)
        {
            ControllerImage.SetActive(Gamepad.current != null);
            ControllerImage.GetComponent<Image>().enabled = PlayerPrefs.GetInt("ControllerOverlay") > 0;
        }
        if (toggleMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggled = !Toggled;
                TogglePauseMenu(Toggled);
            }
            if (Gamepad.current != null)
            {
                if (Gamepad.current.startButton.wasPressedThisFrame)
                {
                    Toggled = !Toggled;
                    TogglePauseMenu(Toggled);
                }
            }
        }
        if (Gamepad.current != null && UsingControllerSelect)
        {
            if (Gamepad.current.dpad.up.wasPressedThisFrame && Index >= 1)
            {
                Index--;
            }
            if (Gamepad.current.dpad.down.wasPressedThisFrame && Index < Buttons.Length - 1)
            {
                Index++;
            }
            if(Buttons[Index].GetComponent<Button>())
            {
                Buttons[Index].GetComponent<Button>().Select();
            }
            if (Buttons[Index].GetComponent<Toggle>())
            {
                Buttons[Index].GetComponent<Toggle>().Select();
            }
            if (Gamepad.current.aButton.wasPressedThisFrame && CanUseSystem)
            {
                if (Buttons[Index].GetComponent<Button>())
                {
                    Buttons[Index].GetComponent<Button>().onClick.Invoke();
                }
                if (Buttons[Index].GetComponent<Toggle>())
                {
                    Buttons[Index].GetComponent<Toggle>().isOn = !Buttons[Index].GetComponent<Toggle>().isOn;
                }
            }
        }
    }
    public void OnOverlayToggleChanged(bool param)
    {
        PlayerPrefs.SetInt("ControllerOverlay", Convert.ToInt32(param));
    }

    public void GoToSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsMenu.SetActive(false);
    }

    public void TogglePauseMenu(bool param)
    {
        toggleMenu.SetActive(param);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}