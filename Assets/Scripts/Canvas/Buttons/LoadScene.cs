using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Canvas.Buttons
{
    public class LoadScene : MonoBehaviour
    {
        public void Load(string sceneName)
        {
            new SceneHandler().LoadSceneByName(sceneName);
        }
    }
}
