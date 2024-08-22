using System;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Pipe
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private Pipe _pipePrefab;
        [SerializeField] private float _spawnInterval = 1;


        private float _xSpawnPosition;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private void Start()
        {
            _xSpawnPosition = transform.position.x;
        }

        public void StartSpawning()
        {
            Spawn();
            
            Observable.Interval(TimeSpan.FromSeconds(_spawnInterval))
                .TakeWhile(_ => !Game.IsGamePaused)
                .Subscribe(
                    _ => Spawn(),
                    _ =>  Debug.Log("StopPipeSpawning"))
                .AddTo(_disposable);
        }

        private void Spawn()
            {
                try
                {
                    float newYSpawnPosition = Random.Range(-0.55f, 1.8f);
                    Instantiate(_pipePrefab, new Vector3(_xSpawnPosition, newYSpawnPosition),
                        Quaternion.identity);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Spawn failed: {e.Message}");
                }
            }

            private void OnDestroy()
            {
                _disposable.Dispose();
            }
        }
    }