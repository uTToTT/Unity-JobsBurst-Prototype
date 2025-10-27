using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerShootingSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }

    protected override void OnUpdate()
    {
        //if (!Input.GetKeyDown(KeyCode.Space))
        //{
        //    return;
        //}

        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        foreach(RefRO<LocalTransform> localTransform in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>())
        {
            Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
            EntityManager.SetComponentData(spawnedEntity, new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Rotation = Quaternion.identity,
                Scale = 1f
            });

        }
    }
}
