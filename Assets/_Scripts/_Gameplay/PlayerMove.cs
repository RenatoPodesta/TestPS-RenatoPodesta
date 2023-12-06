using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player")]

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 100f;

    [SerializeField]
    float rotationSpeed = 0f;

    [SerializeField]
    float drift = 1;

    Vector2 movementPlayer;

    float rotation = 0f;

    private Animator _animatorController;



    private void Start()
    {
        Time.timeScale = 1f;
        _animatorController = GetComponent<Animator>();
    }
    void Update()
    {
        movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MovePlayer(movementPlayer);
        OnRotation();
        OnDrift();
    }

    void MovePlayer(Vector3 direction)
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }

    void OnRotation()
    {
        rotation = rotation - (rotationSpeed * movementPlayer.x);
        rb.MoveRotation(rotation);
    }

    void OnDrift()
    {
        Vector2 velocityUp = transform.up * Vector2.Dot(rb.velocity, transform.up);
        Vector2 velocityRight = transform.right * Vector2.Dot(rb.velocity, transform.right);
        rb.velocity = (velocityUp + velocityRight) * drift;
    }
}
