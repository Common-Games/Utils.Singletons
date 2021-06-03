using JetBrains.Annotations;

namespace CGTK.Utilities.Singletons
{
	#if ODIN_INSPECTOR
	using MonoBehaviour = Sirenix.OdinInspector.SerializedMonoBehaviour;
	#else
	using MonoBehaviour = UnityEngine.MonoBehaviour;
	#endif
	
	//TODO: Check for multiple instances on loading a different scene.

	/// <summary> Singleton for <see cref="MonoBehaviour"/>s - If an instance already exists it will use that, if not it'll create one.</summary>
	/// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
	public abstract class MonoBehaviourSingleton_Ensured<T> : MonoBehaviour
		where T : MonoBehaviourSingleton_Ensured<T>
	{
		#region Properties
		
		private static T _internalInstance;

		/// <summary> The static reference to the Instance </summary>
		[PublicAPI]
		public static T Instance
		{
			get
			{
				if (InstanceExists) return _internalInstance;
				//Debug.Log("Finding Singleton");
				_internalInstance = FindObjectOfType<T>();

				if (InstanceExists) return _internalInstance;

				_internalInstance = CreateSingleton();
				//Debug.Log("Creating Singleton");

				return _internalInstance;
			}
			protected set => _internalInstance = value;
		}
		
		/// <summary> Whether a Instance of the Singleton exists </summary>
		[PublicAPI]
		public static bool InstanceExists => (_internalInstance != null);
		
		#endregion

		#region Methods

		protected virtual void Reset() => Register();
		protected virtual void Awake() => Register();
		protected virtual void OnEnable() => Register();
		
		protected virtual void OnDisable() => Unregister();

		[UsedImplicitly]
		private static T CreateSingleton()
		{
			UnityEngine.GameObject __ownerObject = new(name: $"[{typeof(T).Name}]");
			T __instance = __ownerObject.AddComponent<T>();

			return __instance;
		}
		
		/// <summary> Associate Singleton with new instance. </summary>
		private void Register()
		{
			if(InstanceExists && (Instance != this)) //Prefer using already existing Singletons.
			{
				#if UNITY_EDITOR
				if (!UnityEngine.Application.isPlaying)
				{
					DestroyImmediate(obj: this);
				}
				else
				{
					Destroy(obj: this);
				}
				#else
				Destroy(obj: this);
				#endif
				
				return;
			}
			
			Instance = this as T;
		}
		
		/// <summary> Clear Singleton association </summary>
		private void Unregister()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}
		
		#endregion
	}
}