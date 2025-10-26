using Unity.Entities;
using UnityEngine;

public class RotateSpeedAuthoring : MonoBehaviour
{
    public float Value;

    private class Baker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateSpeed
            {
                Value = authoring.Value,
            });
        }
    }
}
public struct RotateSpeed : IComponentData
{
    public float Value;
}
