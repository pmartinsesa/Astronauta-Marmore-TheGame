using Assets.Scripts.Astronauta.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Managers
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [Header("Coin")]
        public int coinAmount = 0;

        [Header("Events")]
        public UnityEvent<int> updateCoinCounterOnScreen;

        private void Awake()
        {
            coinAmount = 0;
        }
        public void UpdateCoinAmount()
        {
            coinAmount++;
            updateCoinCounterOnScreen.Invoke(coinAmount);
        }
    }
}
