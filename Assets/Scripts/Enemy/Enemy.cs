using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        //[Header("Damage settings")]
       // public UnityEvent enemyLifeBase;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Bullet")
            {
                Destroy(gameObject);
            }
        }
    }
}