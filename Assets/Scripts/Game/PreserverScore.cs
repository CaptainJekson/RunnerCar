using UnityEngine;

public class PreserverScore : MonoBehaviour
{
    [SerializeField] private PlayerCar _player;

    private void OnEnable()
    {
        _player.PlayerLoad += ToLoad;
        _player.PlayerDied += ToSave;
    }

    private void OnDisable()
    {
        _player.PlayerLoad -= ToLoad;
        _player.PlayerDied -= ToSave;
    }

    private void ToSave()
    {
        PlayerPrefs.SetInt("Score", _player.Score);
    }

    private void ToLoad()
    {
        _player.AddScore(PlayerPrefs.GetInt("Score"));
    }
}
