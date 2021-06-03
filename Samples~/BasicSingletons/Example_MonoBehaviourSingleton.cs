using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Samples.Singletons.Basic
{
	using CGTK.Utilities.Singletons;

	/// <summary>
	/// A Singleton which you can create in the inspector or at runtime, it'll automatically register itself.
	/// It's not lazy, so you *have* to create it yourself.
	/// </summary>
	public sealed class Example_MonoBehaviourSingleton : MonoBehaviourSingleton<Example_MonoBehaviourSingleton>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Example MonoBehaviour Singleton";
	}
}