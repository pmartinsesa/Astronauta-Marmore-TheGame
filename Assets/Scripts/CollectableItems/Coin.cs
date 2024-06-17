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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                OnCollect();
            };
        }

        public void OnCollect()
        {
            addCoinsByType.Invoke(type);
            SelfDestroy();
        }

        public void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}
