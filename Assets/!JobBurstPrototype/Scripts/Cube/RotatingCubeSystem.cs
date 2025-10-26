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
        RotatingCubeJob rotatingCubeJob = new RotatingCubeJob
        {
            DeltaTime = SystemAPI.Time.DeltaTime
        };

        rotatingCubeJob.ScheduleParallel();
    }

    [BurstCompile]
    [WithNone(typeof(Player))]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float DeltaTime;

        public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
        {
            float power = 1f;

            //for (int i = 0; i < 10_000; i++)
            //{
            //    power *= 2f;
            //    power /= 2f;
            //}

            localTransform = localTransform.RotateY(rotateSpeed.Value * DeltaTime * power);
        }
    }

}
