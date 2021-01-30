using JetBrains.Annotations;

namespace CGTK.Utilities.Singletons
{
	
	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour; 
	#else 
	using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif
	
	/// <summary> Singleton for <see cref="MonoBehaviour"/>s</summary>
	/// <typeparam name="T"> Type of the Singleton. </typeparam>
	public abstract class Singleton<T> : MonoBehaviour 
		where T : Singleton<T>
	{
		#region Properties

		private static T _internalInstance = null;

		/// <summary> The static reference to the Instance </summary>
		[PublicAPI]
		public static T Instance
		{
			get => _internalInstance ??= FindObjectOfType<T>();
			protected set => _internalInstance = value;
		}

		/// <summary> Whether a Instance of the Singleton exists </summary>
		[PublicAPI]
		public static bool InstanceExists => (_internalInstance != null);

		#endregion

		#region Methods

		/// <summary> OnEnable method to associate Singleton with Instance </summary>
		protected virtual void OnEnable()
		{
			if (InstanceExists && Instance != this)
			{
				Destroy(Instance);
			}
			
			Instance = this as T;
		}

		/// <summary> OnDisable method to clear Singleton association </summary>
		protected virtual void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		#endregion
	}
}