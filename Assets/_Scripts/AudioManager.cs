using System;
using UnityEngine;
using Random = System.Random;

namespace _Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        [SerializeField] private Sound[] _sFXSounds, _musicSouds;
        [SerializeField] private AudioSource _musicSource, _sfxSource;
        
        private readonly Random _random = new Random();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void PlayMusic(string name)
        {
            if (_musicSource == null)
            {
                Debug.Log($"Music Source Is Null");
                throw new NullReferenceException($"Music Source Is Null");
            }

            Sound[] sounds = Array.FindAll(_musicSouds, x => x.Name == name);
            if (sounds.Length == 0)
            {
                Debug.Log($"Sound {name} Not Found");
                throw new ArgumentException($"Sound {name} Not Found");
            }
            else
            {
                int soundID = _random.Next(0, sounds.Length);
                _musicSource.clip = sounds[soundID].Clip;
                _musicSource.Play();
            }
        }

        public void PlaySFX(string name)
        {
            if (_sfxSource == null)
            {
                Debug.Log($"SFX Source Is Null");
                throw new NullReferenceException($"SFX Source Is Null");
            }

            Sound[] sounds = Array.FindAll(_sFXSounds, x => x.Name == name);
            if (sounds.Length == 0)
            {
                Debug.Log($"Sound {name} Not Found");
                throw new ArgumentException($"Sound {name} Not Found");
            }
            else
            {
                int soundID = _random.Next(0, sounds.Length);
                _sfxSource.clip = sounds[soundID].Clip;
                _sfxSource.Play();
            }
        }
    }
}