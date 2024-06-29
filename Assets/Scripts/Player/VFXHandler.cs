using UnityEngine;

namespace Assets.Scripts.Player
{
    public class VFXHandler : MonoBehaviour
    {
        [Header("Particles")]
        public ParticleSystem runningParticle;
        public ParticleSystem jumpParticle;

        [Header("Animator")]
        public Animator animator;

        public void vfxRunning()
        {
            vfxController(runningParticle, "ANIM_Astronaut_Run");
        }

        public void vfxJump()
        {
            vfxController(jumpParticle, "ANIM_Astronaut_Jump_Up");
        }

        private void vfxController(ParticleSystem particleSystem, string animatorStateName)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animatorStateName))
            {
                if (!particleSystem.isPlaying)
                    particleSystem.Play();
            }
            else
            {
                if (particleSystem.isPlaying)
                    particleSystem.Stop();
            }
        }
    }
}
