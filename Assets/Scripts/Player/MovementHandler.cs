using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Player
{
    // Criar uma trigger para iniciar a animação de landing antes de tocar o chão.





    public class MovementHandler : MonoBehaviour
    {
        [Header("Physics settings")]
        public float speed = 12f;
        public float speedDash = 30f;
        public float jumpForce = 15f;
        public Vector2 friction = new Vector2(0.1f, 0);

        [Header("Animation settings")]
        public Animator animator;
        public Vector3 jumpScaleAnimation = new Vector3(0.5f, 1.5f, 0f);
        public float jumpAnimationDuration = .5f;
        public Vector3 fallScaleAnimation = new Vector3(1.5f, .3f, 0f);
        public float fallAnimationDuration = 1f;
        public Vector3 dashScaleAnimation = new Vector3(0.2f, 1f, 0f);
        public float dashAnimationDuration = 1.5f;
        public Ease ease = Ease.OutBack;

        [Header("Player settings")]
        public int maxJumps = 2;
        
        private Rigidbody2D _rigidbody2D;
        private float _currentSpeed;
        private int _currentJumps;
        private bool _isDashing;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _currentSpeed = speed;
            _isDashing = false;
            _currentJumps = 0;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _currentJumps = 0;
            AnimationHandler(fallScaleAnimation, fallAnimationDuration);
            animator.SetBool("onGround", true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            animator.SetBool("onGround", false);
        }

        private void Update()
        {
            Jump();
            Movement();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _currentJumps < maxJumps)
            {
                _currentJumps++;
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                animator.SetBool("isJumping", true);
                animator.SetBool("onGround", false);

                AnimationHandler(jumpScaleAnimation, jumpAnimationDuration);
            }

            if (_rigidbody2D.velocity.y < 0)
            {
                animator.SetBool("isJumping", false);
            }

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
                animator.SetBool("isDashing", _isDashing);
                _currentSpeed = speedDash;

                AnimationHandler(dashScaleAnimation, dashAnimationDuration);
                Invoke(nameof(StopDash), .5f);
            }
        }

        private void AnimationHandler(Vector3 animationScale, float duration)
        {
            var isRightDirection = gameObject.transform.localScale.x > 0;

            if (!isRightDirection)
            {
                animationScale.x *= -1;
                gameObject.transform.DOScaleX(-1, 0.1f);
            }
            else
            {
                gameObject.transform.DOScaleX(1, 0.1f);
            }

            DOTween.Kill(gameObject.transform);
            gameObject.transform
                   .DOScale(animationScale, duration)
                   .SetEase(ease)
                   .From();
        }

        private void StopDash()
        {
            _currentSpeed = speed;
            _isDashing = false;
            animator.SetBool("isDashing", _isDashing);
        }

        private void DefaultMovement()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.velocity = new Vector2(_currentSpeed, _rigidbody2D.velocity.y);
                gameObject.transform.DOScaleX(1, 0.1f);
                animator.SetBool("isRunning", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.velocity = new Vector2(-_currentSpeed, _rigidbody2D.velocity.y);
                gameObject.transform.DOScaleX(-1, 0.1f);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            ReduceVelocityByFriction();
        }

        private void ReduceVelocityByFriction()
        {
            if (_rigidbody2D.velocity.x > 0)
            {
                _rigidbody2D.velocity -= friction;
            }
            else if (_rigidbody2D.velocity.x < 0)
            {
                _rigidbody2D.velocity += friction;
            }
        }
    }
}