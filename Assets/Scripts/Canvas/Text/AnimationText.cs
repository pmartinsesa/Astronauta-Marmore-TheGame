using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Canvas.Text
{
    public class AnimationText : MonoBehaviour
    {
        [Header("Text")]
        public GameObject text;

        [Header("Animation Settings")]
        public float duration;
        public Ease ease = Ease.OutBack;

        private void Awake()
        {
            ShowText();
        }

        private void ShowText()
        {
            text.transform
                .DOScale(1, duration)
                .SetEase(ease)
                .From(Vector3.zero);
        }
    }
}
