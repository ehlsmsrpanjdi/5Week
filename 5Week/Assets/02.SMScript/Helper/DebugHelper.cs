using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
public static class DebugHelper
{
    public static void Log(string message, Object context)
    {
        Debug.Log($"{context.name}   and  {message}");
    }
    public static void LogWarning(string message, Object context)
    {
        Debug.Log($"{context.name}   and  {message}");

    }
    public static void LogError(string message, Object context)
    {
        Debug.Log($"{context.name}   and  {message}");

    }
    public static void LogException(System.Exception exception, Object context)
    {
        Debug.LogException(exception);
    }
}
#endif
