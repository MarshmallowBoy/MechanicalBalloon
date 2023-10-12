using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueObject : Attraction
{
    public bool isOnButton;
    public SpriteRenderer spriteRender;

    public void Awake()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        spriteRender.flipX = Random.Range(0, 1) > 0;
    }
    public override void Attract()
    {
        IsAttracting = !isOnButton;
        base.Attract();
    }
}
