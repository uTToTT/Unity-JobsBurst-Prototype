using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnCubesSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubesConfig>();
        RequireForUpdate<SpawnCubesController>();
    }

    protected override void OnUpdate()
    {
        var config = SystemAPI.GetSingleton<SpawnCubesConfig>();
        var controllerEntity = SystemAPI.GetSingletonEntity<SpawnCubesController>();
        var controller = SystemAPI.GetSingleton<SpawnCubesController>();

        if (!controller.ShouldSpawn)
            return;

        var gridSize = controller.GridSize;
        var startPos = controller.StartPos;
        var offset = controller.Offset;

        int spawned = 0;

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                float3 position = startPos + new float3(x * offset, 0f, y * offset);

                Entity e = EntityManager.Instantiate(config.CubePrefabEntity);
                EntityManager.SetComponentData(e, new LocalTransform
                {
                    Position = position,
                    Rotation = quaternion.identity,
                    Scale = 1f
                });

                spawned++;
            }
        }

        EntityManager.SetComponentData(
            SystemAPI.GetSingletonEntity<SpawnCubesController>(),
            new SpawnCubesController
            {
                ShouldSpawn = false,
                GridSize = controller.GridSize,
                StartPos = controller.StartPos,
                Offset = controller.Offset,
            });

        controller.ShouldSpawn = false;
        controller.SpawnedAmount += spawned;

        EntityManager.SetComponentData(controllerEntity, controller);
    }
}


public struct SpawnCubesController : IComponentData
{
    public bool ShouldSpawn;
    public float2 GridSize;
    public float3 StartPos;
    public float Offset;
    public int SpawnedAmount;
}