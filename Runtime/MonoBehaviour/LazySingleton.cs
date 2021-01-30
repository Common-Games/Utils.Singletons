using System;
using UnityEngine;

using JetBrains.Annotations;

namespace CGTK.Utilities.Singletons
{

	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour;
	#else
	using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif

	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s</summary>
	/// <typeparam name="T"> Type of the Singleton. </typeparam>
	public abstract class LazySingleton<T> : MonoBehaviour
		where T : LazySingleton<T>
	{
		private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);

		[PublicAPI]
		public static T Instance => LazyInstance.Value;

		[PublicAPI] 
		public bool InstanceExists => LazyInstance.IsValueCreated;

		[UsedImplicitly]
		public static T CreateSingleton()
		{
			GameObject __ownerObject = new GameObject(name: $"[{typeof(T).Name}]");
			T __instance = __ownerObject.AddComponent<T>();

			return __instance;
		}
	}
}