using Unity.Burst;
using Unity.Entities;

public partial struct HandleCubesSystem : ISystem
{
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
    [WithAll(typeof(RotatingCube))]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float DeltaTime;

        public void Execute(RotatingMovingCubeAspect rotatingMovingCubeAspect)
        {
            rotatingMovingCubeAspect.MoveAndRotate(DeltaTime);
        }
    }
}
