using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private int _timeToDeath = 1;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
                StartCoroutine(DestroyEnemy());
            }
        }

        private IEnumerator DestroyEnemy()
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            yield return new WaitForSeconds(_timeToDeath);
            Destroy(gameObject);
        }
    }
}