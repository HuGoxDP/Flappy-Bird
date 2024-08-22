using UnityEngine;

namespace _Scripts.Pipe
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private float _pipeSpeed;
        private void FixedUpdate()
        {
            if (!Game.IsGamePaused)
            {
                 transform.Translate(new Vector3(-_pipeSpeed,0 ,0));
            }
        }
    }
}