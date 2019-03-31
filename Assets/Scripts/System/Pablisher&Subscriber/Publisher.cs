using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Publisher : IPublisher
{
    private readonly HashSet<ISubscriber> subscribers = new HashSet<ISubscriber>();
    public void Clear()
    {
        foreach (ISubscriber subscriber in subscribers)
        {
            if(subscriber is IPublishable)
            {
                ((IPublishable)subscriber).Publisher.Clear();
            }

            subscribers.Clear();
        }
    }

    public void Notify<TMassage>(TMassage massage)
    {
        foreach (ISubscriber subscriber in subscribers)
        {
            if(subscriber is ISubscriber<TMassage>)
            {
                ((ISubscriber<TMassage>)subscriber).UpdateData(massage);
            }

            if(subscriber is IPublishable)
            {
                ((IPublishable)subscriber).Publisher.Notify(massage);
            }
        }
    }

    public void Subscribe(ISubscriber subscrider)
    {
        subscribers.Add(subscrider);
    }

    public void UnSubscride(ISubscriber subscriber)
    {
        if(subscriber is IPublishable)
        {
            ((IPublishable)subscriber).Publisher.Clear();
        }

        subscribers.Remove(subscriber);
    }
}

public interface IPublisher
{
    void Notify<TMassage>(TMassage massage);
    void Subscribe(ISubscriber subscriber);
    void UnSubscride(ISubscriber subscrider);
    void Clear();
}

public interface IPublishable
{
    Publisher Publisher { get; }
}
