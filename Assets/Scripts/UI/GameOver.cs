using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button _buttonReset;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _buttonReset.onClick.AddListener(ResetGame);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
