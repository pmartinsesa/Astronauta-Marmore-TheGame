using Assets.Scripts.Managers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.EndGame
{
    public class GoToMenu : MonoBehaviour
    {
        public string sceneName;

        private void Awake()
        {
            StartCoroutine(JumpMenu());
        }

        private IEnumerator JumpMenu()
        {
            yield return new WaitForSeconds(10f);
            new SceneHandler().LoadSceneByName(sceneName);
        }
    }
}
