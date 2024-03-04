using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Buttons
{
    public class MenuButtonsHandler : MonoBehaviour
    {
        [Header("Buttons")]
        public List<GameObject> buttons;

        [Header("Animation Settings")]
        public float duration;
        public Ease ease = Ease.OutBack;

        private void Awake()
        {
            ShowButtons();
        }

        public void ShowButtons()
        {
            buttons.ForEach(b =>
            {
                StartCoroutine(AnimateButtons(b));
            });
        }

        private IEnumerator AnimateButtons(GameObject button)
        {
            button.transform
                .DOScale(1, duration)
                .SetEase(ease)
                .From(Vector3.zero);
            
            yield return new WaitForSeconds(duration);
        }
    }
}
