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
	/// <remarks> Do NOT create one inside of the inspector, it will not recognize them! For that, use the EnsuredSingletons.</remarks>
	/// <typeparam name="T"> Type of the Singleton. </typeparam>
	public abstract class LazySingleton<T> : MonoBehaviour
		where T : LazySingleton<T>
	{
		//private static readonly Lazy<T> LazyInstance = new Lazy<T>(valueFactory: CreateAction);
		private static readonly Lazy<T> LazyInstance = new(CreateLazySingleton);

		private static Func<T> Create { get; set; }

		[PublicAPI]
		public static T Instance => LazyInstance.Value;

		[PublicAPI] 
		public bool InstanceExists => LazyInstance.IsValueCreated;

		protected LazySingleton()
		{
			Create = CreateLazySingleton;
		}

		protected LazySingleton(in Func<T> create)
		{
			Create = create;
		}

		[UsedImplicitly]
		private static T CreateLazySingleton()
		{
			GameObject __ownerObject = new(name: $"[{typeof(T).Name}]");
			T __instance = __ownerObject.AddComponent<T>();

			return __instance;
		}
	}
}