using Unity.Entities;
using UnityEngine;

public class SpawnCubesConfigAuthoring : MonoBehaviour
{
    public GameObject CubePrefab;
    public int AmountToSpawn;


    public class Baker : Baker<SpawnCubesConfigAuthoring>
    {
        public override void Bake(SpawnCubesConfigAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new SpawnCubesConfig
            {
                CubePrefabEntity = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
                AmountToSpawn = authoring.AmountToSpawn,
            });
        }
    }
}

public struct SpawnCubesConfig : IComponentData
{
    public Entity CubePrefabEntity;
    public int AmountToSpawn;
}