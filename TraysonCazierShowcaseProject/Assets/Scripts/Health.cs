using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject[] HealthObjects;
    public int MaxHealth = 3;
    public int HealthInt;
    public Animator anim;
    public void ChangeHealthValue(int value)
    {
        HealthInt = value;
        for (int i = 0; i < MaxHealth; i++)
        {
            HealthObjects[i].SetActive(false);
        }
        for (int i = 0; i < HealthInt; i++)
        {
            HealthObjects[i].SetActive(true);
        }
        anim.Play("HealthAnim");
        if(HealthInt <= 0){
            SceneManager.LoadScene(3);
        }
    }
}
