using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneHandler : MonoBehaviour
    {
        public void LoadSceneByName(string sceneName)
        {
           SceneManager.LoadScene(sceneName);
        }
    }
}
