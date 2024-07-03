using UnityEngine;

namespace Assets.Scripts.Life
{
    public class LifeBase : MonoBehaviour
    {
        [Header("Health settings")]
        public int life = 3;

        private int _currentLife;

        private void Awake()
        {
            _currentLife = life;
        }

        public bool onDamage(int damage)
        {
            _currentLife -= damage;

            return _currentLife <= 0;
        }
    }
}
