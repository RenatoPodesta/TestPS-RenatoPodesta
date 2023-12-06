using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [HideInInspector] public float lifeBar;

    [Header("Player")]
    [SerializeField]
    GameObject player;

    [Header("Chaser Parameters")]
    [SerializeField]
    float speedChaser;

    [SerializeField]
    float minDistance;

    [SerializeField]
    float life;

    [SerializeField]
    float maxLife = 3;

    private float _distance;
    private Animator _animatorController;

    Transform myTransform;
    Transform tranformPlayer;


    private void Start()
    {
        _animatorController = GetComponent<Animator>();
        myTransform = transform;
        tranformPlayer = player.transform;
        lifeBar = 1.2f;
        ChangeSprite();
    }

    private void FixedUpdate()
    {
        _distance = Vector2.Distance(myTransform.position, tranformPlayer.position);
        Vector2 direction = (tranformPlayer.position - myTransform.position).normalized;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (_distance < minDistance)
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, tranformPlayer.position, speedChaser * Time.fixedDeltaTime);
            myTransform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        LookingForPlayer();

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
        if (collision.gameObject.name == "Player")
        {
            _animatorController.SetTrigger("OnCollisionC");
        }

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
                _animatorController.SetTrigger("OnCollisionC");
            }
        }
    }

    void ChangeSprite()
    {
        _animatorController.SetInteger("ChaserLife", (int)life);
    }

    void LookingForPlayer()
    {
        RaycastHit2D[] colliders;

        colliders = Physics2D.CircleCastAll(myTransform.position, minDistance, Vector2.up);

        foreach(RaycastHit2D element in colliders)
        {
            if(element.transform.gameObject.tag == "Player")
            {
                tranformPlayer = element.transform;
            }
        }
    }
}
