using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct RotatingCubeSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<RotateSpeed>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        return;
        foreach ((RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed)
            in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>().WithAll<RotatingCube>())
        {
            float power = 1f;

            for (int i = 0; i < 100_000; i++)
            {
                power *= 2f;
                power /= 2f;
            }

            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.Value * SystemAPI.Time.DeltaTime * power);
        }
    }
}
