using Assets.Scripts.Enums;
using DG.Tweening;
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
        public UnityEvent onAudioPlay;

        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>() ?? null;
        }

        private void Start()
        {
            SetIdleAnimation();
        }

        private void SetIdleAnimation()
        {
            transform
                .DOMoveY(-9.8f, .6f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
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
            onAudioPlay.Invoke();

            SelfDestroy();
        }

        public void SelfDestroy()
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            DOTween.Kill(gameObject.transform);
            
            Destroy(gameObject, 1f);
        }
    }
}
