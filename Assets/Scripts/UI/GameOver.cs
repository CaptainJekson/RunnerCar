using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button _resetButton;
    [SerializeField] private PlayerCar _player;
    [SerializeField] private GameObject _gameOverPanel;

    private void Awake()
    {
        _resetButton.onClick.AddListener(ResetGame);
    }

    private void OnEnable()
    {
        _player.PlayerDied += EnablePanel;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= EnablePanel;
    }

    private void EnablePanel()
    {
        _gameOverPanel.SetActive(true);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
