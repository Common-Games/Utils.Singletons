/*
using UnityEngine;

using JetBrains.Annotations;

namespace CGTK.Utilities.Singletons
{
	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
	/// <typeparam name="T"> Type of the Singleton. </typeparam>
	public abstract class PersistentLazySingleton<T> : LazySingleton<T> 
		where T : PersistentLazySingleton<T>
	{
		protected PersistentLazySingleton() : base(create: CreatePersistentSingleton)
		{ }

		[UsedImplicitly]
		private static T CreatePersistentSingleton()
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
*/

using UnityEngine;

namespace CGTK.Utilities.Singletons
{

	/*
	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour;
	#else
	using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif
	*/
	
	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
	/// <remarks> Do NOT create one inside of the inspector, it will not recognize them! For that, use the EnsuredSingletons.</remarks>
	/// <typeparam name="T"> Type of the Singleton. </typeparam>
	[RequireComponent(requiredComponent: typeof(DontDestroyOnLoad))]
	public abstract class LazySingletonPersistent<T> : LazySingleton<T>
		where T : LazySingletonPersistent<T>
	{
		/*
		private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreatePersistentLazySingleton);

		[PublicAPI]
		public static T Instance => LazyInstance.Value;

		[PublicAPI] 
		public bool InstanceExists => LazyInstance.IsValueCreated;
		

		[UsedImplicitly]
		private static T CreatePersistentLazySingleton()
		{
			GameObject __ownerObject = new GameObject(name: $"[{typeof(T).Name}]");
			T __instance = __ownerObject.AddComponent<T>();

			return __instance;
		}
		*/
	}
}