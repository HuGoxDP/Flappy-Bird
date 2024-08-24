using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Bird
{
    public class Bird : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;

        public Action OnDie;
        public Action OnPointTake;
        public Action OnGameStart;
            
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private BirdControl _birdControl;
        private Sequence _flySequence;

        private bool _isRotatedToUp;
        private void Awake()
        {
            _birdControl = GetComponent<BirdControl>();
            _animator = GetComponentInChildren<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.simulated = false;
        }
        
        
        private void Start()
        {
            StayFlying();
            _birdControl.Tap.started += StartGame;
            _birdControl.Tap.started += Jump;
        }
        
        
        private void StayFlying()
        {
            _flySequence?.Kill();
            var position = transform.position;
            _flySequence = DOTween.Sequence().Append(transform.DOMoveY(position.y +0.1f, 0.3f))
                .Append(transform.DOMoveY(position.y - 0.1f, 0.3f))
                .SetLoops(-1)
                .SetLink(gameObject);
        }
        
        
        private void StartGame(InputAction.CallbackContext callbackContext)
        {
            _birdControl.Tap.started -= StartGame;
            OnGameStart?.Invoke();
            _rigidbody2D.simulated = true;
            _flySequence?.Kill();
        }

        private void FixedUpdate()
        {
            
            if (!Game.IsGamePaused & _rigidbody2D.velocity.y > 0 && !_isRotatedToUp)
            {
                _isRotatedToUp = true;
                transform.DOLocalRotate(new Vector3(0,0,15f), 0.2f);
            }

            if (!Game.IsGamePaused & _rigidbody2D.velocity.y < 0 && _isRotatedToUp)
            {
                _isRotatedToUp = false;
                transform.DOLocalRotate(new Vector3(0,0,-15f), 0.2f);
            }
        }

        private void Jump(InputAction.CallbackContext callbackContext)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
            AudioManager.Instance.PlaySFX("Wing");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Pipe"))
            {
                OnPointTake?.Invoke();
                AudioManager.Instance.PlaySFX("Point");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnDie?.Invoke();
            if (other.gameObject.CompareTag("Pipe"))
            {
                _birdControl.DisableControl();
                other.collider.enabled = false;
                AudioManager.Instance.PlaySFX("Die");
            }
            else
            {
                _birdControl.DisableControl();
                _animator.enabled = false;
                _rigidbody2D.simulated = false;   
                AudioManager.Instance.PlaySFX("Hit");

            }
        }
    }
}
