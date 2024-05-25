using UnityEngine;

namespace Assets.Scripts.Canvas.Buttons
{
    public class Exit : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
