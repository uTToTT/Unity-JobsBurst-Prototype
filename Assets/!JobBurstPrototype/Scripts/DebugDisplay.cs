using TMPro;
using UnityEngine;

public class DebugDisplay : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text _fpsText;
    [SerializeField] private TMP_Text _cubesAmountText;

    [Header("Settings")]
    [SerializeField] private float _updateRate = 0.5f;
    [SerializeField] private int _goodFps = 60;
    [SerializeField] private int _warningFps = 30;

    private float _timer;
    private int _frames;
    private float _fps;

    private void Update()
    {
        _frames++;
        _timer += Time.unscaledDeltaTime;

        if (_timer >= _updateRate)
        {
            _fps = _frames / _timer;
            _frames = 0;
            _timer = 0f;

            UpdateFPSCount(_fps);
        }
    }

    public void UpdateCubesAmount(int amount)
    {
        if (_cubesAmountText != null)
            _cubesAmountText.text = $"CUBES: {amount}";
    }

    public void UpdateFPSCount(float fps)
    {
        if (_fpsText == null)
            return;

        if (fps >= _goodFps)
            _fpsText.color = Color.green;
        else if (fps >= _warningFps)
            _fpsText.color = Color.yellow;
        else
            _fpsText.color = Color.red;

        _fpsText.text = $"FPS: {fps:0}";
    }
}
