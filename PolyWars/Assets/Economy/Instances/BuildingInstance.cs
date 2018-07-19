using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;

using UnityEngine;

[System.Serializable]
public unsafe struct BuildingInstance : IComponentData
{
    public fixed float jobAmounts[6];
    public fixed float storage[6];
    public Building* template;
}

public unsafe class BuildingInstanceSystem : JobComponentSystem
{
    [BurstCompile]
    struct BuildingInstanceUpdate : IJobProcessComponentData<BuildingInstance>
    {
        public float dt;

        public void Execute(ref BuildingInstance data)
        {
            int canRun = math.bool_to_int(math.all(new bool2(
                math.all(new bool3(math.all(new bool2(
                        math.greaterThanEqual(data.storage[0] + (*data.template).ioDelta[0] * dt, 0),
                        math.lessThanEqual(data.storage[0] + (*data.template).ioDelta[0] * dt, (*data.template).capacity[0])
                    )),
                    math.all(new bool2(
                        math.greaterThanEqual(data.storage[1] + (*data.template).ioDelta[1] * dt, 0),
                        math.lessThanEqual(data.storage[1] + (*data.template).ioDelta[1] * dt, (*data.template).capacity[1])
                    )),
                    math.all(new bool2(
                        math.greaterThanEqual(data.storage[2] + (*data.template).ioDelta[2] * dt, 0),
                        math.lessThanEqual(data.storage[2] + (*data.template).ioDelta[2] * dt, (*data.template).capacity[2])
                    ))
                )),
                math.all(new bool3(math.all(new bool2(
                        math.greaterThanEqual(data.storage[3] + (*data.template).ioDelta[3] * dt, 0),
                        math.lessThanEqual(data.storage[3] + (*data.template).ioDelta[3], (*data.template).capacity[3])
                    )),
                    math.all(new bool2(
                        math.greaterThanEqual(data.storage[4] + (*data.template).ioDelta[4] * dt, 0),
                        math.lessThanEqual(data.storage[4] + (*data.template).ioDelta[4], (*data.template).capacity[4])
                    )),
                    math.all(new bool2(
                        math.greaterThanEqual(data.storage[5] + (*data.template).ioDelta[5] * dt, 0),
                        math.lessThanEqual(data.storage[5] + (*data.template).ioDelta[5], (*data.template).capacity[5])
                    ))
                ))
             )));

            data.storage[0] += canRun * (*data.template).ioDelta[0] * dt;
            data.storage[1] += canRun * (*data.template).ioDelta[1] * dt;
            data.storage[2] += canRun * (*data.template).ioDelta[2] * dt;
            data.storage[3] += canRun * (*data.template).ioDelta[3] * dt;
            data.storage[4] += canRun * (*data.template).ioDelta[4] * dt;
            data.storage[5] += canRun * (*data.template).ioDelta[5] * dt;

            data.jobAmounts[0] += canRun * (*data.template).ioDelta[0] * dt;
            data.jobAmounts[1] += canRun * (*data.template).ioDelta[1] * dt;
            data.jobAmounts[2] += canRun * (*data.template).ioDelta[2] * dt;
            data.jobAmounts[3] += canRun * (*data.template).ioDelta[3] * dt;
            data.jobAmounts[4] += canRun * (*data.template).ioDelta[4] * dt;
            data.jobAmounts[5] += canRun * (*data.template).ioDelta[5] * dt;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new BuildingInstanceUpdate() { dt = Time.deltaTime };
        return job.Schedule(this, inputDeps);
    }
}