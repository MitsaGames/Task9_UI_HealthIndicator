using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private float _changeSpeed = 10.0f;
    [SerializeField] private float _threshold = 0.1f;

    private Character _character;
    private Coroutine _smoothChange;

    public void Render(Character character)
    {
        _character = character;

        if (_smoothChange != null)
        {
            StopCoroutine(_smoothChange);
        }

        _smoothChange = StartCoroutine(SmoothChange());
    }

    public IEnumerator SmoothChange()
    {
        while((_healthBar.value - _character.Health) > _threshold || (_healthBar.value - _character.Health) < -_threshold)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _character.Health, _changeSpeed * Time.deltaTime);
            _healthText.text = Mathf.Round(_healthBar.value).ToString();

            yield return null;
        }
    }
}
