using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CollectableItems
{
    public class Coin : MonoBehaviour, ICollectibleItem
    {
        [Header("Coin")]
        public ECoinType type;

        [Header("Events")]
        public UnityEvent<ECoinType> addCoinsByType;

        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>() ?? null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                OnCollect();
            };
        }

        public void OnCollect()
        {
            if (type.Equals(ECoinType.Big))
                _particleSystem?.Play();

            addCoinsByType.Invoke(type);
            SelfDestroy();
        }

        public void SelfDestroy()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
