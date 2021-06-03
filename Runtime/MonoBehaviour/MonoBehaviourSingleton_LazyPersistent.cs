using UnityEngine;

namespace CGTK.Utilities.Singletons
{
	//basically just here for documentation
	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour; 
	#else 
    using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif
	
	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
	/// <remarks> Do NOT create one inside of the inspector, it will not recognize them! For that, use the EnsuredSingletons.</remarks>
	/// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
	[RequireComponent(requiredComponent: typeof(DontDestroyOnLoad))]
	public abstract class MonoBehaviourSingleton_LazyPersistent<T> : MonoBehaviourSingleton_Lazy<T>
		where T : MonoBehaviourSingleton_LazyPersistent<T>
	{
		
	}
}