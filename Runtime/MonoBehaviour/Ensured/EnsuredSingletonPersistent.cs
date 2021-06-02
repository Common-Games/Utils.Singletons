using UnityEngine;

namespace CGTK.Utilities.Singletons
{
	/// <summary> Singleton for <see cref="MonoBehaviour"/>s - that persists across scenes - If an instance already exists it will use that, if not it'll create one.</summary>
	/// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
	//[RequireComponent(requiredComponent: typeof(DontDestroyOnLoad))]
	public abstract class EnsuredSingletonPersistent<T> : EnsuredSingleton<T>
		where T : EnsuredSingletonPersistent<T>
	{
		protected override void Awake()
		{
			base.Awake();

			if(Application.isPlaying)
			{
				DontDestroyOnLoad(this.gameObject);
			}
		}
	}
}