using UnityEngine;

namespace CGTK.Utilities.Singletons
{
    //basically just here for documentation
    #if ODIN_INSPECTOR
    using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour; 
    #else 
    using MonoBehaviour = UnityEngine.MonoBehaviour;
    #endif

    /// <summary> Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
    /// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
    //[RequireComponent(requiredComponent: typeof(DontDestroyOnLoad))]
    public abstract class MonoBehaviourSingleton_Persistent<T> : MonoBehaviourSingleton<T>
        where T : MonoBehaviourSingleton_Persistent<T>
    {
        protected override void Awake()
        {
            base.Awake();

            if (Application.isPlaying)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}