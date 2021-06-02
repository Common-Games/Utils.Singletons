using System.Linq;

using UnityEngine;

using JetBrains.Annotations;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CGTK.Utilities.Singletons
{
	
	#if ODIN_INSPECTOR
	using ScriptableObject = Sirenix.OdinInspector.SerializedScriptableObject; 
	#else 
	using ScriptableObject = UnityEngine.ScriptableObject;
	#endif
	
	/// <summary> Singleton for <see cref="ScriptableObject"/>s</summary>
	/// <typeparam name="T"> Type of the Singleton. CRTP (the inheritor)</typeparam>
	public abstract class EnsuredScriptableSingleton<T> : ScriptableObject 
		where T : EnsuredScriptableSingleton<T>
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

				T[] __found = Resources.FindObjectsOfTypeAll<T>();
				if (__found.HasElements())
				{
					return _internalInstance = __found[0];	
				}

				return _internalInstance = CreateInstance<T>();
			}
			protected set
			{
				_internalInstance = value;	
				
				#if UNITY_EDITOR
				if(_internalInstance == null) return;
				
				Object[] __preloadedAssets = PlayerSettings.GetPreloadedAssets();

				if (__preloadedAssets.Contains(_internalInstance)) return;

				__preloadedAssets.Add(_internalInstance);

				PlayerSettings.SetPreloadedAssets(__preloadedAssets);
				#endif
			}
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

		/// <summary> Associate Singleton with new instance. </summary>
		//[RuntimeInitializeOnLoadMethod]
		private void Register()
		{
			if(InstanceExists && (Instance != this)) //Prefer using already existing Singletons.
			{
				#if UNITY_EDITOR
				if (!EditorApplication.isPlaying)
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