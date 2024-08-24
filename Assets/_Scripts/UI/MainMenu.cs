using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string _nextSceneName;

        public void ChangeScene()
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
