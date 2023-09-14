using UnityEngine;

public static class ErrorManager 
{
    public static void LogError(string errorMessage)
    {
        Debug.LogError(errorMessage);
    }

    public static void LogWarning(string warningMessage)
    {
        Debug.LogWarning(warningMessage);
    }
}