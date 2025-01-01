using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SubJect
{
    public static List<Iobserver> Observers = new();

    public static void Register(Iobserver observer)
    {
        Observers.Add(observer);
    }

    public static void Unregister(Iobserver observer)
    {
        Observers.Remove(observer);
    }

    public static void Notify(string key)
    {
        foreach (var observer in Observers)
        {
            observer.onNotify(key);
        }
    }
}