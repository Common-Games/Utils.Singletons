using UnityEngine;

using JetBrains.Annotations;

namespace CommonGames.Samples.Singletons.Basic
{
	using CGTK.Utilities.Singletons;
	
	//[CreateAssetMenu]
	public sealed class Example_ScriptableObjectSingleton_Ensured : ScriptableObjectSingleton_Ensured<Example_ScriptableObjectSingleton_Ensured>
	{
		[field: SerializeField]
		public string Info { get; [UsedImplicitly] private set; } = "Example ScriptableObject Singleton Ensured";
	}
}