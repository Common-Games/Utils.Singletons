using UnityEngine;

using JetBrains.Annotations;

using CGTK.Utilities.Singletons;

namespace CommonGames.Samples
{
	/// <summary>
	/// A MonoBehaviour Singleton that can ONLY be created lazily. It will NOT use singletons added in the inspector.
	/// </summary>
	public sealed class ExampleLazySingleton : EnsuredSingleton<ExampleLazySingleton>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Lazy MonoBehaviour Singleton Test.";
	}
}