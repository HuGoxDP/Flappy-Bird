﻿using System;
using UnityEngine;

namespace _Scripts
{
    [Serializable]
    public class Sound
    {
       [SerializeField] private string _name;
       [SerializeField] private AudioClip _clip;

       public string Name => _name;
       public AudioClip Clip => _clip;
    }
}