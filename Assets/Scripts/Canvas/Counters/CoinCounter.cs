using TMPro;
using UnityEngine;

namespace Assets.Scripts.Canvas.Counters
{
    public class CoinCounter : MonoBehaviour
    {
        [Header("Counter Component")]
        public TMP_Text counterOnScreen;
 
        public void UpdateCounterOnScreen(int counter)
        {
            counterOnScreen.SetText(counter.ToString());
        }
    }
}
