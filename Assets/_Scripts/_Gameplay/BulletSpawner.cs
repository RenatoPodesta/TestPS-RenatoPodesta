using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Bullet")]

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    public float speedBullet;

    [SerializeField] float destroyTime = 2;

    [Header("PositionBullet")]
    [SerializeField] Transform bulletSpawnerPosition;
    [SerializeField] Transform[] spawnerPositions;

    [Header("Animator")]
    [SerializeField] private Animator _animatorController;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) 
        {
            _animatorController.SetTrigger("OnShoot");
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Q)) 
        {
            _animatorController.SetTrigger("OnShoot");
            MultipleShoot();
        }

    }

    void Shoot()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, bulletSpawnerPosition.position, bulletSpawnerPosition.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(-bulletSpawnerPosition.up * speedBullet);
        Destroy(bullet.gameObject, destroyTime);
    }

    void MultipleShoot()
    {
        foreach (Transform spawnP in spawnerPositions)
        {
            SideShoot(spawnP);
        }
    }

    void SideShoot(Transform spawnPoint)
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(-spawnPoint.right * speedBullet);
        Destroy(bullet.gameObject, destroyTime);
    }
}
