using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterLife : MonoBehaviour
{
    Vector3 localScale;

    [SerializeField]
    EnemyShooter enemyParent;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = enemyParent.lifeBar;
        transform.localScale = localScale;
    }
}
