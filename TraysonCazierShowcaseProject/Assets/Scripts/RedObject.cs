using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObject : Attraction
{
    public GameObject particleSystem1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.GetComponent<Health>().ChangeHealthValue(Player.GetComponent<Health>().HealthInt-1);
            GameObject temp = Instantiate(particleSystem1);
            temp.transform.parent = null;
            temp.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    public void Repelled()
    {
        Invoke("AttractRed", 3);
    }

    void AttractRed()
    {
        IsAttracting = true;
    }
}
