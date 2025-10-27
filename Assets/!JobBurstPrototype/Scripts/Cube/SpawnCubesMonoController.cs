using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnCubesMonoController : MonoBehaviour
{
    private EntityManager _entityManager;
    private Entity _controllerEntity;

    [SerializeField] private bool _enabled;
    [SerializeField] private Vector2 _gridSize;
    [SerializeField] private float _offset;
    [SerializeField] private DebugDisplay _debugDisplay;

    private float3 _startPos;
    private float _timer;

    private void Start()
    {
        if (!_enabled) return;

        _startPos = new float3(
            -(_gridSize.x - 1) * _offset / 2f,
            0f,
            -(_gridSize.y - 1) * _offset / 2f
            );

        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        _controllerEntity = _entityManager.CreateEntity(typeof(SpawnCubesController));

        _entityManager.SetComponentData(_controllerEntity, new SpawnCubesController
        {
            ShouldSpawn = true,
            GridSize = _gridSize,
            StartPos = _startPos,
            Offset = _offset,
        });
    }

    private void Update()
    {
        if (!_enabled) return;

        _timer += Time.deltaTime;
        if (_timer < 1f) return;
        _timer = 0f;

        if (_entityManager.Exists(_controllerEntity))
        {
            var data = _entityManager.GetComponentData<SpawnCubesController>(_controllerEntity);
            _debugDisplay.UpdateCubesAmount(data.SpawnedAmount);
        }
    }
}
