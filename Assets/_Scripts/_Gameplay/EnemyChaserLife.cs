using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserLife : MonoBehaviour
{
    Vector3 localScale;

    [SerializeField]
    EnemyChaser enemyParent;

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
