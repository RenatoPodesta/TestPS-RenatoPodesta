using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject _player;

    [SerializeField]
    public float speedBullet;

    Rigidbody2D rb;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Direction();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Direction()
    {
        Vector3 direction = _player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speedBullet;

        float rotation = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
