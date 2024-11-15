using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public LayerMask targetLayer;
        public Transform source;
        public GameObject bulletPrefab;
        public float projectileSpeed;
        public float fireRate;

        private float timer;
        public bool isFiring;

        private void LaunchBullet()
        {
            Debug.Log("launch bullet");
            GameObject bullet = Instantiate(bulletPrefab, source.position, source.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = transform.up * projectileSpeed;
        }
        
        public void Fire()
        {
            if (isFiring && timer <= 0)
            {
                LaunchBullet();
                timer = fireRate;
            }
        }

        public void Update()
        {
            if (isFiring)
            {
                timer -= Time.deltaTime;
            }
        }
        
    }
}