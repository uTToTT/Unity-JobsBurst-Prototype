using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public readonly partial struct RotatingMovingCubeAspect : IAspect
{
    public readonly RefRO<RotatingCube> RotatingCube;
    public readonly RefRW<LocalTransform> LocalTransform;
    public readonly RefRO<RotateSpeed> RotateSpeed;
    public readonly RefRO<Movement> Movement;

    [BurstCompile]
    public void MoveAndRotate(float deltaTime)
    {
        LocalTransform.ValueRW = LocalTransform.ValueRO.RotateY(RotateSpeed.ValueRO.Value * deltaTime);
        LocalTransform.ValueRW = LocalTransform.ValueRO.Translate(Movement.ValueRO.MovementVector * deltaTime);
    }
}
