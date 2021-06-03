using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Samples.Singletons.Basic
{
	using CGTK.Utilities.Singletons;
	
	//[CreateAssetMenu]
	public sealed class ExampleEnsuredScriptableObjectSingleton : EnsuredScriptableSingleton<ExampleEnsuredScriptableObjectSingleton>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Example ScriptableObject Singleton Ensured";
	}
}