using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class StartAssistant : MonoBehaviour
{
    [SerializeField] private PlayerCar _player;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.PlayerStarted += DisableText;
    }

    private void OnDisable()
    {
        _player.PlayerStarted -= DisableText;
    }

    private void DisableText()
    {
        _text.enabled = false;
    }
}
