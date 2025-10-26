using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SpawnCubesSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubesConfig>();
    }

    protected override void OnUpdate()
    {
        this.Enabled = false;

        SpawnCubesConfig spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

        for (int i = 0; i < spawnCubesConfig.AmountToSpawn; i++)
        {
            Entity spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
            EntityManager.SetComponentData(spawnedEntity, new LocalTransform
            {
                Position = new float3(UnityEngine.Random.Range(-10, +5), 1, UnityEngine.Random.Range(-5f, +10f)),
                Rotation = Quaternion.identity,
                Scale = 1f
            });

        }
    }
}
