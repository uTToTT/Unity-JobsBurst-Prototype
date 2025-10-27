using System.Collections.Generic;
using UnityEngine;

// Only test
public class CubesRotatorManager : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly List<GameObject> _cubes = new();

    private bool _isStarted;

    public void Register(GameObject cube)
    {
        if (_isStarted) return;

        _cubes.Add(cube);
    }

    public void Unregister(GameObject cube)
    {
        if (_isStarted) return;

        _cubes.Remove(cube);
    }

    public void StartRotating() => _isStarted = true;
    public void StopRotating() => _isStarted = false;

    private void Update()
    {
        if (!_isStarted) return;

        Rotate();
    }

    private void Rotate()
    {
        for (int i = 0; i < _cubes.Count; i++)
        {
            _cubes[i].transform.Rotate(Vector3.up, _speed * Time.deltaTime);
        }
    }
}
