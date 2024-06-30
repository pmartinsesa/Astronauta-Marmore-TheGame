using Assets.Scripts.ScriptableObjects.PlayerTypes;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class MovementHandler : MonoBehaviour
    {
        [Header("Player settings")]
        public SOPlayer playerSettings;

        [Header("VFX settings")]
        public ParticleSystem jumpParticle;
        public ParticleSystem runningParticle;

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private float _currentSpeed;
        private int _currentJumps;
        private bool _isDashing;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animator = gameObject.GetComponentInChildren<Animator>();
            _currentSpeed = playerSettings.speed;
            _isDashing = false;
            _currentJumps = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Collectable")) return;

            _currentJumps = 0;
            AnimationHandler(playerSettings.fallScaleAnimation, playerSettings.fallAnimationDuration);
            Invoke(nameof(VFXJump), .3f);


            _animator.SetBool("onGround", true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Collectable")) return;

            _animator.SetBool("onGround", false);
        }

        private void Update()
        {
            Jump();
            Movement();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _currentJumps < playerSettings.maxJumps)
            {
                _currentJumps++;
                _rigidbody2D.velocity = Vector2.up * playerSettings.jumpForce;
                _animator.SetBool("isJumping", true);
                _animator.SetBool("onGround", false);

                VFXJump();
                AnimationHandler(playerSettings.jumpScaleAnimation, playerSettings.jumpAnimationDuration);
            }

            if (_rigidbody2D.velocity.y < 0)
            {
                _animator.SetBool("isJumping", false);
            }

        }

        private void VFXJump()
        {
            jumpParticle.Play();
        }

        private void Movement()
        {
            DashHandler();
            DefaultMovement();
        }

        private void DashHandler()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !_isDashing)
            {
                _isDashing = true;
                _animator.SetBool("isDashing", _isDashing);
                _currentSpeed = playerSettings.speedDash;

                AnimationHandler(playerSettings.dashScaleAnimation, playerSettings.dashAnimationDuration);
                Invoke(nameof(StopDash), .5f);
            }
        }

        private void AnimationHandler(Vector3 animationScale, float duration)
        {
            var isRightDirection = gameObject.transform.localScale.x > 0;

            if (!isRightDirection)
            {
                animationScale.x *= -1;
                gameObject.transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector2(1, 1);
            }

            DOTween.Kill(gameObject.transform);
            gameObject.transform
                   .DOScale(animationScale, duration)
                   .SetEase(playerSettings.ease)
                   .From();
        }

        private void StopDash()
        {
            _currentSpeed = playerSettings.speed;
            _isDashing = false;
            _animator.SetBool("isDashing", _isDashing);
        }

        private void DefaultMovement()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.velocity = new Vector2(_currentSpeed, _rigidbody2D.velocity.y);
                gameObject.transform.DOScaleX(1, 0.1f);
                _animator.SetBool("isRunning", true);
                VFXRunning();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.velocity = new Vector2(-_currentSpeed, _rigidbody2D.velocity.y);
                gameObject.transform.DOScaleX(-1, 0.1f);
                _animator.SetBool("isRunning", true);
                VFXRunning();
            }
            else
            {
                runningParticle.Stop();
                _animator.SetBool("isRunning", false);
            }

            ReduceVelocityByFriction();
        }

        private void VFXRunning()
        {
            if (_animator.GetBool("onGround"))
            {
                if (!runningParticle.isPlaying)
                    runningParticle.Play();
            }
            else
            {
                runningParticle.Stop();
            }
        }

        private void ReduceVelocityByFriction()
        {
            if (_rigidbody2D.velocity.x > 0)
            {
                _rigidbody2D.velocity -= playerSettings.friction;
            }
            else if (_rigidbody2D.velocity.x < 0)
            {
                _rigidbody2D.velocity += playerSettings.friction;
            }
        }
    }
}