using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonObject : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    public SpriteRenderer Renderer1;
    public int id;
    public int CollidersOnButton = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollidersOnButton++;
        if (CollidersOnButton > 1)
        {
            return;
        }
        Renderer1.sprite = Sprite2;
        GameObject[] Gates = GameObject.FindGameObjectsWithTag("Gate");
        for (int i = 0; i < Gates.Length; i++)
        {
            Gates[i].BroadcastMessage("PlayEffects", id);
        }
        if (collision.GetComponentInParent<BlueObject>())
        {
            collision.GetComponentInParent<BlueObject>().isOnButton = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CollidersOnButton--;
        if (CollidersOnButton > 0)
        {
            return;
        }
        CollidersOnButton = 0;
        Collider2D[] results = new Collider2D[0];
        ContactFilter2D contactFilter = new ContactFilter2D { };
        if (gameObject.GetComponent<Collider2D>().OverlapCollider(contactFilter, results) > 0)
        {
            return;
        }
        Renderer1.sprite = Sprite1;
        GameObject[] Gates = GameObject.FindGameObjectsWithTag("Gate");
        for (int i = 0; i < Gates.Length; i++)
        {
            Gates[i].BroadcastMessage("UndoEffects", id);
        }
        if (collision.GetComponentInParent<BlueObject>())
        {
            collision.GetComponentInParent<BlueObject>().isOnButton = false;
        }
    }
}
