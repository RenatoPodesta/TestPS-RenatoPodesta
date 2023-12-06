using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [HideInInspector] public float lifeBar;

    [Header("Life")]
    [SerializeField]
    float life;

    [SerializeField]
    float maxLife = 3;

    [SerializeField]
    public Sprite[] spritesShip;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    private Animator _animatorController;

    void Start()
    {
        lifeBar = 1.2f;
        _animatorController = GetComponent<Animator>();
        ChangeSprite();
    }

    void Update()
    {

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
        if (collision.gameObject.tag == "Chaser")
        {
            HUDHandler.Instance.OnGameOver();
            _animatorController.SetTrigger("OnCollision");

        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            LifeManager(-1f);
            lifeBar -= 0.4f;
            ChangeSprite();
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                lifeBar = 0;
                life = 0;
                Debug.Log(life);
                _animatorController.SetTrigger("OnCollision");
                HUDHandler.Instance.OnGameOver();
            }
        }
    }

    void ChangeSprite()
    {
        _animatorController.SetInteger("Life", (int)life);
    }
}
