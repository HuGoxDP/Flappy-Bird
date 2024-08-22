using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Bird
{
    public class BirdControl : MonoBehaviour
    {
        private BirdInputAction _birdInputAction;
        public InputAction Tap => _birdInputAction.Bird.Tap;
        private void Awake()
        {
            _birdInputAction = new BirdInputAction();
            _birdInputAction.Enable();
        }
        
        public void EnableControl()
        {        
            _birdInputAction.Enable();
        }
        
        public void DisableControl()
        {        
            _birdInputAction.Disable();
        }
    }
}