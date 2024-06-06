using Assets.Scripts.Astronauta.Core;
using Assets.Scripts.ScriptableObjects.PrimitiveTypes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [Header("Coin")]
        public SOInt coin;

        [Header("Events")]
        public UnityEvent<int> updateCoinCounterOnScreen;

        private void Awake()
        {
            coin.value = 0;
        }
        public void UpdateCoinAmount()
        {
            coin.value++;
            updateCoinCounterOnScreen.Invoke(coin.value);
        }
    }
}
