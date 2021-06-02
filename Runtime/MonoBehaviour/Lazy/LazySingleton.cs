using System;

using JetBrains.Annotations;

namespace CGTK.Utilities.Singletons
{

	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour;
	#else
	using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif

	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s</summary>
	/// <remarks> Do NOT create one inside of the inspector, it will not recognize them! For that, use the EnsuredSingletons.</remarks>
	/// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
	public abstract class LazySingleton<T> : MonoBehaviour
		where T : LazySingleton<T>
	{
		private static readonly Lazy<T> LazyInstance = new(CreateSingleton);

		[PublicAPI]
		public static T Instance => LazyInstance.Value;

		[PublicAPI] 
		public bool InstanceExists => LazyInstance.IsValueCreated;

		[UsedImplicitly]
		private static T CreateSingleton()
		{
			UnityEngine.GameObject __ownerObject = new(name: $"[{typeof(T).Name}]");
			T __instance = __ownerObject.AddComponent<T>();

			return __instance;
		}
	}
}