﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class ShootHandler : MonoBehaviour
    {
        [Header("Gun Configuration")]
        public float fireRate;
        public GameObject gun;
        public GameObject bullet;

        private bool canFire = true;

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetMouseButton(0))
            {
                if (canFire)
                {
                    canFire = false;
                    onFire();
                }
            }
        }

        private void onFire()
        {
            bullet.transform.position = gun.transform.position;
            Instantiate(bullet);
            StartCoroutine(FireRateHandler());
        }

        private IEnumerator FireRateHandler()
        {
            yield return new WaitForSeconds(1 / fireRate);
            canFire = true;
        }
    }
}
