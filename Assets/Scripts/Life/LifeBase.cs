using UnityEngine;

namespace Assets.Scripts.Life
{
    public class LifeBase : MonoBehaviour
    {
        [Header("Health settings")]
        public int life = 3;

        private int _currentLife;
        private bool _isDead;

        private void Awake()
        {
            _currentLife = life;
            _isDead = false;
        }

        public bool onDamage(int damage)
        {
            _currentLife -= damage;

            return _currentLife <= 0;
        }
    }
}
