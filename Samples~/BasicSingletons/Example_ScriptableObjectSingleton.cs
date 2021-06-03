using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Samples.Singletons.Basic
{
	using CGTK.Utilities.Singletons;

	//[CreateAssetMenu]
	public sealed class Example_ScriptableObjectSingleton : ScriptableObjectSingleton<Example_ScriptableObjectSingleton>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Example ScriptableObject Singleton";
	}
}