using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class SceneHandler : MonoBehaviour
    {
        public void LoadSceneByName(string sceneName)
        {
           SceneManager.LoadScene(sceneName);
        }
    }
}
