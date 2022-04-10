using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public Dictionary<Type, Action<EventTrigger>> prepareEventListeners = new Dictionary<Type, Action<EventTrigger>>();
    public Dictionary<Type, Action<EventTrigger>> performEventListeners = new Dictionary<Type, Action<EventTrigger>>();

    #region Singleton
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void AddPrepareListener(Type eventType, Action<EventTrigger> listenerMethod)
    {
        AddListener(eventType, listenerMethod, prepareEventListeners);
    }

    public void AddPerformListener(Type eventType, Action<EventTrigger> listenerMethod)
    {
        AddListener(eventType, listenerMethod, performEventListeners);
    }

    private void AddListener(Type eventType, Action<EventTrigger> listenerMethod, Dictionary<Type, Action<EventTrigger>> eventListeners)
    {
        if (!eventListeners.ContainsKey(eventType))
        {
            Action<EventTrigger> methodHolder = null;
            eventListeners.Add(eventType, methodHolder);
        }

        eventListeners[eventType] += listenerMethod;
    }

    public void RemovePrepareListener(Type eventType, Action<EventTrigger> listenerMethod)
    {
        RemoveListener(eventType, listenerMethod, prepareEventListeners);
    }

    public void RemovePerformListener(Type eventType, Action<EventTrigger> listenerMethod)
    {
        RemoveListener(eventType, listenerMethod, performEventListeners);
    }

    private void RemoveListener(Type eventType, Action<EventTrigger> listenerMethod, Dictionary<Type, Action<EventTrigger>> eventListeners)
    {
        eventListeners[eventType] -= listenerMethod;
    }
    
    public void InvokePrepareEvent(EventTrigger eventTrigger)
    {
        InvokeEvent(eventTrigger, prepareEventListeners);
    }

    public void InvokePerformEvent(EventTrigger eventTrigger)
    {
        InvokeEvent(eventTrigger, performEventListeners);
    }

    private void InvokeEvent(EventTrigger eventTrigger, Dictionary<Type, Action<EventTrigger>> eventListeners)
    {
        eventListeners[eventTrigger.GetType()].Invoke(eventTrigger);
    }
}
