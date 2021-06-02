using UnityEngine;

namespace CGTK.Utilities.Singletons
{
	/// <summary> Lazy Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes. </summary>
	/// <remarks> Do NOT create one inside of the inspector, it will not recognize them! For that, use the EnsuredSingletons.</remarks>
	/// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
	[RequireComponent(requiredComponent: typeof(DontDestroyOnLoad))]
	public abstract class LazySingletonPersistent<T> : LazySingleton<T>
		where T : LazySingletonPersistent<T>
	{
		
	}
}