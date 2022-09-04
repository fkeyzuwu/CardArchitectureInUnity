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
    void Awake()
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

    //use listener events in order to react to a specific event type. whenever the event will happen, the action will activate
    public void AddPrepareListener<T>(Action<EventTrigger> listenerMethod) where T : EventTrigger
    {
        AddListener<T>(listenerMethod, prepareEventListeners);
        Debug.Log($"Method {listenerMethod.Method.Name} for prepareEventListeners added");
    }

    public void AddPerformListener<T>(Action<EventTrigger> listenerMethod) where T : EventTrigger
    {
        AddListener<T>(listenerMethod, performEventListeners);
        Debug.Log($"Method {listenerMethod.Method.Name} for preformEventListeners added");
    }

    private void AddListener<T>(Action<EventTrigger> listenerMethod, Dictionary<Type, Action<EventTrigger>> eventListeners)
    {
        if (!eventListeners.ContainsKey(typeof(T)))
        {
            Action<EventTrigger> methodHolder = null;
            eventListeners.Add(typeof(T), methodHolder);
        }

        eventListeners[typeof(T)] += listenerMethod;
    }

    //use to remove a listner method from activating when the event happens
    public void RemovePrepareListener<T>(Action<EventTrigger> listenerMethod) where T : EventTrigger
    {
        RemoveListener<T>(listenerMethod, prepareEventListeners);
        Debug.Log($"Method {listenerMethod.Method.Name} for prepareEventListeners removed");
    }

    public void RemovePerformListener<T>(Action<EventTrigger> listenerMethod) where T : EventTrigger
    {
        RemoveListener<T>(listenerMethod, performEventListeners);
        Debug.Log($"Method {listenerMethod.Method.Name} for preformEventListeners removed");
    }

    private void RemoveListener<T>(Action<EventTrigger> listenerMethod, Dictionary<Type, Action<EventTrigger>> eventListeners)
    {
        eventListeners[typeof(T)] -= listenerMethod;
    }
    
    //use invoke events to invoke a new event so that listneres can react to it
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
        if (eventListeners.ContainsKey(eventTrigger.GetType()))
        {
            eventListeners[eventTrigger.GetType()].Invoke(eventTrigger);
        }

        Debug.Log($"Event of type {eventTrigger.GetType()} Invoked");
    }
}
