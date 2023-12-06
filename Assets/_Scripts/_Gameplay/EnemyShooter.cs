using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [HideInInspector] public float lifeBar;

    [Header("Player")]
    [SerializeField]
    public GameObject player;

    [Header("Bullet")]

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    public float forceBullet;

    [SerializeField] float destroyTime = 2;

    [SerializeField] Transform bulletSpawnerPosition;

    [Header("Shooter Parameters")]
    [SerializeField]
    float speedShooter;

    [SerializeField]
    float life;

    [SerializeField]
    float maxLife = 3;

    [SerializeField]
    float minDistanceToFollow = 6;

    [SerializeField]
    float minDistanceToShoot = 4;

    [SerializeField] float timerBullet = 2;
    
    Transform tr;
    Transform trPlayer;

    private float _distance;
    private float _timer;
    private Animator _ac;


    void Start()
    {
        _ac = GetComponent<Animator>();
        tr = transform;
        trPlayer = player.transform;
        lifeBar = 1.2f;
        ChangeSprite();
    }

    void FixedUpdate()
    {
        Moving();
        LookingForPlayer();
        Distance();
    }

    void LifeManager(float value)
    {
        life += value;

        if (life < 0)
            life = 0;

        if (life > maxLife)
            life = maxLife;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            LifeManager(-1f);
            lifeBar -= 0.4f;
            ChangeSprite();
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                lifeBar = 0;
                life = 0;
                _ac.SetTrigger("OnCollisionS");
            }
        }
    }

    void Shooting()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, bulletSpawnerPosition.position, bulletSpawnerPosition.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(-bulletSpawnerPosition.up * forceBullet);
        _ac.SetTrigger("OnShoot");
        Destroy(bullet.gameObject, destroyTime);
    }

    void Distance()
    {
        float distance = Vector2.Distance(tr.position, trPlayer.position);

        if (distance < minDistanceToShoot)
        {
            Debug.Log(distance);
            _timer += Time.deltaTime;

            if (_timer > timerBullet)
            {
                _timer = 0;
                Shooting();
                Debug.Log("Shooting");
            }
        }
    }

    void Moving()
    {
        _distance = Vector2.Distance(tr.position, trPlayer.position);
        Vector2 direction = (trPlayer.position - tr.position).normalized;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (_distance < minDistanceToFollow)
        {
            tr.position = Vector2.MoveTowards(tr.position, trPlayer.position, speedShooter * Time.fixedDeltaTime);
            tr.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    void ChangeSprite()
    {
        _ac.SetInteger("ShooterLife", (int)life);
    }

    void LookingForPlayer()
    {
        RaycastHit2D[] colliders;

        colliders = Physics2D.CircleCastAll(tr.position, minDistanceToFollow, Vector2.up);

        foreach (RaycastHit2D element in colliders)
        {
            if (element.transform.gameObject.tag == "Player")
            {
                trPlayer = element.transform;
            }
        }
    }
}
