using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.PlayerTypes
{
    [CreateAssetMenu]
    public class SOPlayer : ScriptableObject
    {
        [Header("Physics settings")]
        public float speed;
        public float speedDash;
        public float jumpForce;
        public Vector2 friction;

        [Header("Animation settings")]      
        public Vector3 jumpScaleAnimation;
        public float jumpAnimationDuration;
        
        public Vector3 fallScaleAnimation;
        public float fallAnimationDuration;
        
        public Vector3 dashScaleAnimation;
        public float dashAnimationDuration;
        
        public Ease ease = Ease.OutBack;

        [Header("Player settings")]
        public int maxJumps;
    }
}
