using System.Diagnostics;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
public partial struct Sys : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        var job = new MoveForwardJob
        {
            deltaTime = deltaTime,
        };

        job.ScheduleParallel(); // Schedule the job for parallel execution
    }
}

[BurstCompile]
internal partial struct MoveForwardJob : IJobEntity
{
    public float deltaTime;
    void Execute(ref ComponentTranslatoin translation, 
        in ComponentMoveSpeed moveSpeed)
    {
      // UnityEngine.Debug.Log("move forward");
        translation.value += math.forward() * moveSpeed.value * deltaTime;
    }

}
