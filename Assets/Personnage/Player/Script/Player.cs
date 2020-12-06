using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speedmove = 3;
    public Rigidbody2D rb;
    public Animator animator;
    private bool IsMoving = false;
    private bool m_Isflipped = true;
    Vector2 movement;
    AudioSource audiol;

    private void Start()
    {
        audiol = GetComponent<AudioSource>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (m_Isflipped == false && movement.x > 0)
        {
            Flip();
        }
        else if (m_Isflipped == true && movement.x < 0)
        {
            Flip();
        }
        if (movement.x + movement.y != 0)
        {
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
        if (IsMoving)
        {
            if (audiol.isPlaying == false)
            {
                audiol.Play();
            }
        }
        else
        {
            audiol.Stop();
        }
        animator.SetFloat("Horizontal", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void Flip()
    {
        m_Isflipped = !m_Isflipped;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speedmove * Time.fixedDeltaTime);
    }
}