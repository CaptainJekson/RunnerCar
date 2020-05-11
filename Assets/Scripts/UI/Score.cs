using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(Animator))]
public class Score : MonoBehaviour
{
    [SerializeField] private PlayerCar _player;

    private TMP_Text _text;
    private Animator _animator;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.PointAdded += Refresh;
    }

    private void OnDisable()
    {
        _player.PointAdded -= Refresh;
    }

    private void Refresh()
    {
        _text.text = _player.Score.ToString();
        _animator.SetBool("State", true);
        StartCoroutine(DelayIdleAnimation(0.6f));
    }

    private IEnumerator DelayIdleAnimation(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        _animator.SetBool("State", false);
    }
}
