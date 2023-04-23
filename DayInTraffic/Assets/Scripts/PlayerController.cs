using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject phoneUI1;
    public GameObject phoneUI2;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private bool phone1 = false;
    private bool phone2 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        phoneUI1.SetActive(false);
        phoneUI2.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveInput = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.velocity = moveInput * speed;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    public void UpdateUI(int phoneNumber)
    {
        if (phoneNumber == 1 && !phone1)
        {
            phoneUI1.SetActive(true);
            phone1 = true;
        }

        if (phoneNumber == 2 && !phone2)
        {
            phoneUI2.SetActive(true);
            phone2 = true;
        }
    }
}
