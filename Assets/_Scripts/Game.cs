using System;
using _Scripts.Pipe;
using _Scripts.UI;
using R3;
using UnityEngine;

namespace _Scripts
{
    public class Game : MonoBehaviour
    {
        public static bool IsGamePaused { get; private set; } = true;

        [SerializeField] private Bird.Bird _bird;
        [SerializeField] private PipeSpawner _pipeSpawner;
        [SerializeField] private Score _score;
        [SerializeField] private EndGamePopup _endGamePopup;
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
            _score.OnScoreUpdate?.Invoke(_points);
        }

        private void StopGame()
        {
            IsGamePaused = true;
            Observable.Interval(TimeSpan.FromMilliseconds(2000))
                .Take(1)
                .Subscribe(_ =>
                    {
                        _endGamePopup.gameObject.SetActive(true);
                        _endGamePopup.OnScoreUpdate?.Invoke(_points);
                    }, 
                    _ => Debug.Log($"Show {_endGamePopup}"))
                .AddTo(_endGamePopup);
        }
        
        private void StartGame()
        {
            _bird.OnGameStart -= StartGame;
            IsGamePaused = false;
            _pipeSpawner.StartSpawning();
        }
    }
}