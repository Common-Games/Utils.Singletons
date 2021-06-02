using UnityEngine;

using CGTK.Utilities.Singletons;

namespace CommonGames.Samples
{
	/// <summary>
	/// A Singleton which you can create in the inspector or at runtime, it'll automatically register itself.
	/// It's not lazy, so you *have* to create it yourself.
	/// </summary>
	public sealed class ExampleSingleton : EnsuredSingleton<ExampleSingleton>
	{
		[field: SerializeField]
		public string Info { get; private set; } = "Basic MonoBehaviour Singleton Test.";
	}
}