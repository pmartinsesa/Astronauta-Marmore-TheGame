using Assets.Scripts.Astronauta.Core;
using Assets.Scripts.Enums;
using Assets.Scripts.ScriptableObjects.CollectableTypes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class CollectableManager : Singleton<CollectableManager>
    {
        [Header("Events")]
        public UnityEvent<int> updateCoinCounterOnScreen;

        [Header("Collectable Items")]
        public SOCollectable collectables;

        private void Awake()
        {
            collectables.coins = 0;
        }
        public void UpdateCoinAmount(ECoinType type)
        {
            Debug.Log((int)type);

            collectables.coins += (int)type;
            updateCoinCounterOnScreen.Invoke(collectables.coins);
        }
    }
}
