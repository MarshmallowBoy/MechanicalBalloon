using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gate : MonoBehaviour
{
    public int RequiredCollectables;
    public int ID;
    public bool Button;
    public bool Inverse;
    GameObject Player;
    Collectables Collectables;
    BoxCollider2D boxCollider2D;
    Animator animator;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Collectables = Player.GetComponent<Collectables>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (RequiredCollectables <= Collectables.CollectablesCollected && !Button)
        {
            PlayEffectsIfNotButton();
        }
    }

    void PlayEffectsIfNotButton()
    {
        boxCollider2D.enabled = false;
        animator.Play("Gate_Opening");
    }

    void PlayEffects(int id = 0)
    {
        if (id == ID && Inverse)
        {
            boxCollider2D.enabled = true;
            animator.Play("Gate_Closing");
            return;
        }
        if (id == ID)
        {
            boxCollider2D.enabled = false;
            animator.Play("Gate_Opening");
        }
    }

    void UndoEffects(int id = 0)
    {
        if (id == ID && Inverse)
        {
            boxCollider2D.enabled = false;
            animator.Play("Gate_Opening");
            return;
        }
        if (id == ID)
        {
            boxCollider2D.enabled = true;
            animator.Play("Gate_Closing");
        }
    }
}
