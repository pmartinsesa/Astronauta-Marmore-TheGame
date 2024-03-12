using UnityEngine;

namespace Assets.Scripts.Life
{
    public class LifeBase : MonoBehaviour
    {
        [Header("Health settings")]
        public int baseLife = 15;

        private int _currentLife;
        private bool _isDead;

        private void Awake()
        {
            _currentLife = baseLife;
            _isDead = false;
        }

        public void onDamage(int damage)
        {
            _currentLife -= damage;

            if(_currentLife <= 0 )
                killObject();
        }

        private void killObject()
        {
            if (_isDead) return;

            _isDead = true;
            Destroy(gameObject);
        }
    }
}
