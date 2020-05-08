using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserverScore : MonoBehaviour
{
    [SerializeField] private Player _player;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    private void OnEnable()
    {
        _player.PlayerLoad += () => _player.AddScore(Load());
        _player.PlayerDied += Save;
    }

    private void OnDisable()
    {
        _player.PlayerLoad -= () => _player.AddScore(Load());
        _player.PlayerDied -= Save;
    }

    private void Save(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    private int Load()
    {
        return PlayerPrefs.GetInt("Score");

    }
}
