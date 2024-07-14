using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.EndGame
{
    public class EndGameHandler : MonoBehaviour
    {
        public string sceneName;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                new SceneHandler().LoadSceneByName(sceneName);
            };
        }
    }
}
