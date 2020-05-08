using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class Distance : MonoBehaviour
{
    [SerializeField] private DistanceMeter _distanceMeter;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = Mathf.Round( _distanceMeter.GetDistance()).ToString();
    }
}
