using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool verticalMovement = false;
    public bool dynamicMovement = false;
    public float distance = 5f;
    public bool facingRight = true;

    Rigidbody2D rigidbody2D;
    float distanceTravelled = 0f;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (verticalMovement)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rigidbody2D.MovePosition(position);

        distanceTravelled += speed * Time.deltaTime;

        if (distanceTravelled >= distance)
        {
            if (dynamicMovement)
            {
                if (verticalMovement)
                {
                    verticalMovement = false;
                    direction = facingRight ? 1 : -1;
                }
                else
                {
                    verticalMovement = true;
                    direction = 1;
                }
            }
            else
            {
                direction = -direction;
            }

            distanceTravelled = 0f;

            if (facingRight && direction < 0)
            {
                Flip();
            }
            else if (!facingRight && direction > 0)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameObject.GetComponentInChildren<Canvas>().gameObject.SetActive(true);
        }
    }
}
