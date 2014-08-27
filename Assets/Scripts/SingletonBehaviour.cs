using System;
using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour, new()
{
    private static bool _instantiated;
    private static T _instance;

    private static readonly object Lock = new object();

    public static T Instance
    {
        get
        {
            if (!_instantiated)
            {
                lock (Lock)
                {
                    T[] _objectsFound = FindObjectsOfType<T>();
                    if (_objectsFound.Length == 1)
                    {
                        _instance = _objectsFound[0];
                    }
                    else if (_objectsFound.Length == 0)
                    {
                        _instance = new T();
                    }
                    else if(_objectsFound.Length > 1)
                    {
                        throw new Exception(_objectsFound.Length + " instances of ("
                                            + typeof (T) + ") were found. Can\'t make Singleton");
                    }

                    _instantiated = true;
                }
            }

            return _instance;
        }
    }

    public void OnDestroy()
    {
        _instance = null;
        _instantiated = false;
    }

    protected SingletonBehaviour(){}
}