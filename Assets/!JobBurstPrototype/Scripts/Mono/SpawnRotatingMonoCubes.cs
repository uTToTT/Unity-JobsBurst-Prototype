using UnityEngine;

public class SpawnRotatingMonoCubes : MonoBehaviour
{
    [SerializeField] private bool _enabled;
    [SerializeField] private MonoCube _cubePrefab;
    [SerializeField] private Vector2 _gridSize = new Vector2(5, 5);
    [SerializeField] private float _offset = 2f;
    [SerializeField] private CubesRotatorManager _cubesRotatorManager;
    [SerializeField] private bool _isSelfRotated;
    [SerializeField] private DebugDisplay _display;

    private void Start()
    {
        if (!_enabled) return;
        SpawnCubesInGrid();
    }

    private void SpawnCubesInGrid()
    {
        Vector3 startPos = new Vector3(
            -(_gridSize.x - 1) * _offset / 2f,
            0f,
            -(_gridSize.y - 1) * _offset / 2f
            );

        int spawned = 0;

        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector3 position = startPos + new Vector3(x * _offset, 0f, y * _offset);

                var cube = Instantiate(_cubePrefab, position, Quaternion.identity);

                if (_isSelfRotated)
                {
                    cube.IsShouldRotate = true;
                }
                else
                {
                    _cubesRotatorManager.Register(cube.gameObject);
                }

                spawned++;
            }
        }

        if (_isSelfRotated)
        {

        }
        else
        {
            _cubesRotatorManager.StartRotating();
        }

        _display.UpdateCubesAmount(spawned);
    }
}
