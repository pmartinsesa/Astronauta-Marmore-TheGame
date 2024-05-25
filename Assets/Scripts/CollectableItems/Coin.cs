using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CollectableItems
{
    public class Coin : MonoBehaviour, ICollectibleItem
    {
        [Header("Events")]
        public UnityEvent collectableManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                OnCollect();
            };
        }

        public void OnCollect()
        {
            collectableManager.Invoke();
            SelfDestroy();
        }

        public void SelfDestroy()
        {
           Destroy(gameObject);
        }
    }
}
