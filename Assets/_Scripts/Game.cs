using _Scripts.Pipe;
using UnityEngine;

namespace _Scripts
{
    public class Game : MonoBehaviour
    {
        public static bool IsGamePaused => _isGamePaused;

        [SerializeField] private Bird.Bird _bird;
        [SerializeField] private PipeSpawner _pipeSpawner;

        private static bool _isGamePaused = true;


        private int _points;

        private void Awake()
        {
            _bird.OnDie += StopGame;
            _bird.OnGameStart += StartGame;
            _bird.OnPointTake += AddPoint;
        }

        private void OnDestroy()
        {
            _bird.OnDie -= StopGame;
            _bird.OnPointTake -= AddPoint;

        }

        private void AddPoint()
        {
            Debug.Log("Add Point");
            _points++;
        }

        private void StopGame()
        {
            _isGamePaused = true;
        }
        
        private void StartGame()
        {
            _bird.OnGameStart -= StartGame;
            _isGamePaused = false;
            _pipeSpawner.StartSpawning();
        }
    }
}