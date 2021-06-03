using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Samples.Singletons.Basic
{
	using CGTK.Utilities.Singletons;
	
	/// <summary>
	/// A MonoBehaviour Singleton that can ONLY be created lazily. It will NOT use singletons added in the inspector.
	/// </summary>
	public sealed class ExampleLazySingleton : EnsuredSingleton<ExampleLazySingleton>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Example MonoBehaviour Singleton Lazy.";
	}
}