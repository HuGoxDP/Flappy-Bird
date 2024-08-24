using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class EndGamePopup : MonoBehaviour
    {
        public Action<int> OnScoreUpdate;
        
        [SerializeField] private TextMeshProUGUI _scoreTextMesh;
        [SerializeField] private Button _toMainMenuButton;
        [SerializeField] private string _nextSceneName;

        private void Awake()
        {
            OnScoreUpdate += UpdateScoreText;
            _toMainMenuButton.onClick.AddListener(ChangeScene);
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            OnScoreUpdate -= UpdateScoreText;
        }

        private void UpdateScoreText(int pointsCount)
        {
            try
            {
                _scoreTextMesh.text = pointsCount.ToString();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}