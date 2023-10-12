using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public float Speed;
    public bool IsBlue;
    public bool IsAttracting = true;
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attract();
    }

    public virtual void Attract()
    {
        if (!IsAttracting)
        {
            return;
        }
        float Distance = Vector3.Distance(transform.position, Player.transform.position);
        if (Vector3.Distance(transform.position, Player.transform.position) <= 2 && IsBlue)
        {
            if (!Player.GetComponent<PlayerController>().Attracting)
                return;
            Vector3 direction = Player.transform.position - transform.position;
            rb.velocity = direction * Speed / Distance;
            return;
        }
        if (Vector3.Distance(transform.position, Player.transform.position) <= 2)
        {
            Vector3 direction = Player.transform.position - transform.position;
            rb.velocity = direction * Speed / Distance;
        }
    }
}
