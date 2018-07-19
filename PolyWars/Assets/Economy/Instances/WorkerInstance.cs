using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Unity.Entities;

using UnityEngine;
using UnityEngine.AI;

public unsafe class WorkerInstance : MonoBehaviour
{
    public enum WorkerState { Idle, MovingToExporter, Loading, MovingToImporter, UnLoading, FindingReplacementImporter };

    public JobPair currentJob;
    public float currentLoad;
    public WorkerState currentState;
    public Worker* template;
    public byte owner;
}

public unsafe class WorkerSystem : ComponentSystem
{
    struct Group
    {
        public Transform transform;
        public NavMeshAgent navAgent;
        public WorkerInstance workerInstance;
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Group>())
        {
            switch (e.workerInstance.currentState)
            {
                case WorkerInstance.WorkerState.Idle:
                    e.workerInstance.currentJob = WorldData.worldData.players[e.workerInstance.owner].GetBestJobPair(e.transform.position, (*e.workerInstance.template).capacity);
                    if (e.workerInstance.currentJob.amount > 0)
                    {
                        e.workerInstance.currentState = WorkerInstance.WorkerState.MovingToExporter;
                        e.navAgent.SetDestination((*e.workerInstance.currentJob.exporter).)
                        goto case WorkerInstance.WorkerState.MovingToExporter;
                    }
                    break;

                case WorkerInstance.WorkerState.MovingToExporter:
                    break;

                case WorkerInstance.WorkerState.Loading:
                    break;

                case WorkerInstance.WorkerState.MovingToImporter:
                    break;

                case WorkerInstance.WorkerState.UnLoading:
                    break;

                case WorkerInstance.WorkerState.FindingReplacementImporter:
                    break;
            }
        }
    }
}