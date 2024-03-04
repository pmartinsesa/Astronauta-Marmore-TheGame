using UnityEngine;

namespace Assets.Scripts.Buttons
{
    public class LoadScene : MonoBehaviour
    {
        public void Load(string sceneName)
        {
            new SceneHandler().LoadSceneByName(sceneName);
        }
    }
}
