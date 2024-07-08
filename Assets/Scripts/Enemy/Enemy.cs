using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy settings")]
        public float velocity = 2f;
        public Vector3 damageForce = new Vector3(-30f, 15f, 0f);

        [Header("SFX settings")]
        public AudioSource audioSource;
        public AudioClip deathClips;
        public AudioClip attackClips;

        [Header("Player events settings")]
        public UnityEvent<AudioSource, AudioClip> onSoundPlay;

        private float _timeToDeath = 2f;
        private Animator _animator;

        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            transform.Translate(Vector3.left * (velocity * Time.deltaTime));
            _animator.SetBool("isRunning", true);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                _animator.SetBool("isDead", true);
                velocity = 0;
                onSoundPlay.Invoke(audioSource, deathClips);
                StartCoroutine(DestroyEnemy());
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                onSoundPlay.Invoke(audioSource, attackClips);
                Attack(collision.gameObject);
                Invoke(nameof(AttackStop), .5f);
            }
        }

        private void Attack(GameObject player)
        {
            _animator.SetBool("isAttacking", true);
            player.GetComponent<Rigidbody2D>().velocity = damageForce;
        }

        private void AttackStop()
        {
            _animator.SetBool("isAttacking", false);
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