using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Xml.Schema;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer Sprite;
    public float Speed;
    public Animator animator;
    public bool Attracting = false;
    public InputAction Attraction;
    public InputAction Repel;
    public ParticleSystem particleAttraction;
    public ParticleSystem particleRepel;
    public float repelFloat;
    public int Energy;
    public Slider EnergySlide;
    public FixedJoystick fixedJoystick;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        InvokeRepeating("RefillEnergy", 5, 5);
    }
    private void FixedUpdate()
    {
        float yC = Input.GetAxis("Vertical");
        float xC = Input.GetAxis("Horizontal");
        //Movement
        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            yC = fixedJoystick.Vertical;
            xC = fixedJoystick.Horizontal;
        }
        rb.velocity = new Vector3(xC, yC, 0) * Speed;
    }
    private void OnEnable()
    {
        Attraction.Enable();
        Repel.Enable();
    }

    private void OnDisable()
    {
        Attraction.Disable();
        Repel.Disable();
    }

    void Update()
    {
        EnergySlide.value = Energy;
        float xC = Input.GetAxis("Horizontal");
        if (fixedJoystick.Horizontal != 0)
        {
            xC = fixedJoystick.Horizontal;
        }
        //Animations (When To Do Animation After Stick Has Been Moved How Much)
        if (xC > 0.1f)
        {
            animator.Play("Floating");
            Sprite.flipX = false;
        }
        else if (xC < -0.1f)
        {
            animator.Play("Floating");
            Sprite.flipX = true;
        }
        else
        {
            animator.Play("Idle");
        }
        if (Attraction.triggered)
        {
            Attract();
        }
        if (Repel.triggered)
        {
            RepelFunc();
        }
    }

    public void RepelFunc()
    {
        if (!GetComponent<Health>().anim.GetCurrentAnimatorStateInfo(0).IsName("Energy"))
        {
            GetComponent<Health>().anim.Play("Energy");
        }
        if (Energy <= 0)
        {
            return;
        }
        if (Gamepad.current != null)
        {
            Invoke("TurnOffVibrate", 0.2f);
            Gamepad.current.SetMotorSpeeds(0.123f, 0.235f);
        }
        Energy--;
        Collider2D[] collider1 = Physics2D.OverlapCircleAll(transform.position, 2);
        foreach (var colliderHit in collider1)
        {
            if (colliderHit.CompareTag("Red"))
            {
                colliderHit.GetComponentInParent<RedObject>().IsAttracting = false;
                Vector2 vector2 = new Vector2(colliderHit.transform.position.x - transform.position.x, colliderHit.transform.position.y - transform.position.y);
                colliderHit.GetComponentInParent<Rigidbody2D>().AddForce(vector2 * repelFloat);
                colliderHit.GetComponentInParent<RedObject>().Repelled();
            }
        }
        particleRepel.Play();
    }

    public void Attract()
    {
        if (Gamepad.current != null)
        {
            Invoke("TurnOffVibrate", 0.2f);
            Gamepad.current.SetMotorSpeeds(0.123f, 0.235f);
        }
        Attracting = !Attracting;
        particleAttraction.Play();
        particleAttraction.gameObject.GetComponentInChildren<Light2D>().enabled = Attracting;
    }

    void RefillEnergy()
    {
        if (Energy < 4)
        {
            GetComponent<Health>().anim.Play("Energy");
            Energy++;
        }
    }

    void TurnOffVibrate()
    {
        Gamepad.current.SetMotorSpeeds(0, 0);
    }
}