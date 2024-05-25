using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gun
{
    public class Bullet : MonoBehaviour
    {
        [Header("Bullet Settings")]
        public float speed;
        public int lifeTime;
        
        private GameObject _player;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }

        private void Start()
        {
            Move();
            StartCoroutine(DestroyAmmo());
        }

        private void Move()
        {
            var direction = _player.transform.localScale.x > 0 ? 1 : -1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, 0);
        }

        private IEnumerator DestroyAmmo()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}
