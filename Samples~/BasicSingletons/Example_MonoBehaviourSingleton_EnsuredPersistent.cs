using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Samples.Singletons.Basic
{
	using CGTK.Utilities.Singletons;
	
	/// <summary>
	/// A MonoBehaviour Singleton that can be created explicitly or lazily. If one exists it'll use that, else it'll create one.
	/// </summary>
	public sealed class Example_MonoBehaviourSingleton_EnsuredPersistent : MonoBehaviourSingleton_EnsuredPersistent<Example_MonoBehaviourSingleton_EnsuredPersistent>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Example MonoBehaviour Singleton EnsuredPersistent";
	}
}