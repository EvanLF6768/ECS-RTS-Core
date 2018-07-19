using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Jobs;

using UnityEngine;

[System.Serializable]
public unsafe struct BuildingInstance : IComponentData
{
    public void Initialize()
    {
    }

    public fixed float jobAmounts[6];
    public fixed float storage[6];
    public Building* template;
    public Vector3 entrance;
}

public unsafe class BuildingInstanceSystem : JobComponentSystem
{
    [BurstCompile]
    struct BuildingInstanceUpdate : IJobProcessComponentData<BuildingInstance>
    {
        public float dt;

        public void Execute(ref BuildingInstance data)
        {
            fixed (float* storage = data.storage)
            {
                int canRun = math.bool_to_int(math.all(new bool2(
                    math.all(new bool3(math.all(new bool2(
                            math.greaterThanEqual(storage[0] + (*data.template).ioDelta[0] * dt, 0),
                            math.lessThanEqual(storage[0] + (*data.template).ioDelta[0] * dt, (*data.template).capacity[0])
                        )),
                        math.all(new bool2(
                            math.greaterThanEqual(storage[1] + (*data.template).ioDelta[1] * dt, 0),
                            math.lessThanEqual(storage[1] + (*data.template).ioDelta[1] * dt, (*data.template).capacity[1])
                        )),
                        math.all(new bool2(
                            math.greaterThanEqual(storage[2] + (*data.template).ioDelta[2] * dt, 0),
                            math.lessThanEqual(storage[2] + (*data.template).ioDelta[2] * dt, (*data.template).capacity[2])
                        ))
                    )),
                    math.all(new bool3(math.all(new bool2(
                            math.greaterThanEqual(storage[3] + (*data.template).ioDelta[3] * dt, 0),
                            math.lessThanEqual(storage[3] + (*data.template).ioDelta[3], (*data.template).capacity[3])
                        )),
                        math.all(new bool2(
                            math.greaterThanEqual(storage[4] + (*data.template).ioDelta[4] * dt, 0),
                            math.lessThanEqual(storage[4] + (*data.template).ioDelta[4], (*data.template).capacity[4])
                        )),
                        math.all(new bool2(
                            math.greaterThanEqual(storage[5] + (*data.template).ioDelta[5] * dt, 0),
                            math.lessThanEqual(storage[5] + (*data.template).ioDelta[5], (*data.template).capacity[5])
                        ))
                    ))
                 )));

                storage[0] += canRun * (*data.template).ioDelta[0] * dt;
                storage[1] += canRun * (*data.template).ioDelta[1] * dt;
                storage[2] += canRun * (*data.template).ioDelta[2] * dt;
                storage[3] += canRun * (*data.template).ioDelta[3] * dt;
                storage[4] += canRun * (*data.template).ioDelta[4] * dt;
                storage[5] += canRun * (*data.template).ioDelta[5] * dt;

                fixed (float* jobAmounts = data.jobAmounts)
                {
                    jobAmounts[0] += canRun * (*data.template).ioDelta[0] * dt;
                    jobAmounts[1] += canRun * (*data.template).ioDelta[1] * dt;
                    jobAmounts[2] += canRun * (*data.template).ioDelta[2] * dt;
                    jobAmounts[3] += canRun * (*data.template).ioDelta[3] * dt;
                    jobAmounts[4] += canRun * (*data.template).ioDelta[4] * dt;
                    jobAmounts[5] += canRun * (*data.template).ioDelta[5] * dt;
                }
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new BuildingInstanceUpdate() { dt = Time.deltaTime };
        return job.Schedule(this, inputDeps);
    }
}