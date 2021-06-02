using UnityEngine;

using JetBrains.Annotations;

using CGTK.Utilities.Singletons;

namespace CommonGames.Samples
{
	/// <summary>
	/// A MonoBehaviour Singleton that can be created explicitly or lazily. If one exists it'll use that, else it'll create one.
	/// </summary>
	public sealed class ExampleEnsuredSingleton : EnsuredSingleton<ExampleSingleton>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Ensured MonoBehaviour Singleton Test.";
	}
}