using System;
using System.Collections.Generic;
using UnityEngine;

public class UnityMainThreadDispatcher : MonoBehaviour
{
    private static UnityMainThreadDispatcher instance;
    private static readonly Queue<Action> actionQueue = new Queue<Action>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void Enqueue(Action action)
    {
        lock (actionQueue)
        {
            actionQueue.Enqueue(action);
        }
    }

    private void Update()
    {
        while (actionQueue.Count > 0)
        {
            Action action;
            lock (actionQueue)
            {
                action = actionQueue.Dequeue();
            }
            action?.Invoke();
        }
    }
}