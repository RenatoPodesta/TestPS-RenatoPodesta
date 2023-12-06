using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    Vector3 localScale;

    [SerializeField]
    PlayerLife playerLife;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = playerLife.lifeBar;
        transform.localScale = localScale;
    }
}
