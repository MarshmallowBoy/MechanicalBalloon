using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObject : Attraction
{
    public GameObject particleSystem1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            GameObject temp = Instantiate(particleSystem1);
            temp.transform.parent = null;
            temp.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
