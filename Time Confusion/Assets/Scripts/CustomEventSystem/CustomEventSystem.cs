using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static System.Action SaveInitiated;

    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }
}
