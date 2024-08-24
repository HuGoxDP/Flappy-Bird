using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class Score : MonoBehaviour
    {
        public Action<int> OnScoreUpdate;

        private TextMeshProUGUI _scoreTextMesh;

        private void Awake()
        {
            _scoreTextMesh = GetComponent<TextMeshProUGUI>();
            OnScoreUpdate += UpdateScoreText;
        }

        private void OnDestroy()
        {
            OnScoreUpdate -= UpdateScoreText;
        }

        private void UpdateScoreText(int pointsCount)
        {
            _scoreTextMesh.text = pointsCount.ToString();
        }
    }
}