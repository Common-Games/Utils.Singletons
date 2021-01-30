using UnityEngine;

namespace CGTK.Utilities.Singletons
{
    
	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour; 
	#else 
	using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif
    
	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
	/// <typeparam name="T"> Type of the Singleton. </typeparam>
	public abstract class PersistentLazySingleton<T> : LazySingleton<T> 
		where T : PersistentLazySingleton<T>
	{
		
		public new static T CreateSingleton()
		{
			GameObject __ownerObject = new GameObject(name: $"[{typeof(T).Name}]");
			T __instance = __ownerObject.AddComponent<T>();

			if (Application.isPlaying)
			{
				DontDestroyOnLoad(__ownerObject);
			}

			return __instance;
		}
	}
}