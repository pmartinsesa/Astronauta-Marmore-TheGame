using UnityEngine;

namespace Assets.Scripts.Player
{
    public class DamageHandler : MonoBehaviour
    {
        private const float TIME_TO_DEATH = 3f;
        
        [Header("Life settings")]
        public int life;

        private Animator _animator;

        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
        }

        public void onDamage(int damage)
        {
            life -= damage;
            if (life <= 0)
            {
                _animator.SetBool("isJumping", false);
                _animator.SetBool("isDead", true);
                Destroy(gameObject, TIME_TO_DEATH);
            }
        }


    }
}
