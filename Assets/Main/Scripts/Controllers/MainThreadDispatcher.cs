using System;
using System.Collections.Generic;
using UnityEngine;

public class MainThreadDispatcher : MonoBehaviour
{
    private static MainThreadDispatcher instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public static void ExecuteOnMainThread(Action action)
    {
        if (instance != null)
        {
            instance.Enqueue(action);
        }
    }

    private void Enqueue(Action action)
    {
        lock (queueLock)
        {
            actionQueue.Enqueue(action);
        }
    }

    private readonly Queue<Action> actionQueue = new Queue<Action>();
    private readonly object queueLock = new object();

    private void Update()
    {
        lock (queueLock)
        {
            while (actionQueue.Count > 0)
            {
                actionQueue.Dequeue().Invoke();
            }
        }
    }
}