using UnityEngine;

namespace CGTK.Utilities.Singletons
{
    
    #if ODIN_INSPECTOR
    using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour; 
    #else 
    using MonoBehaviour = UnityEngine.MonoBehaviour;
    #endif
    
    /// <summary> Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
    /// <typeparam name="T"> Type of the Singleton. </typeparam>
    public abstract class PersistentSingleton<T> : Singleton<T> 
        where T : PersistentSingleton<T>
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            if(Application.isPlaying)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}