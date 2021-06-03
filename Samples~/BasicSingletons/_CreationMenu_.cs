using CGTK.Utilities.Singletons;

namespace CommonGames.Samples.Singletons.Basic
{
	/// <summary>
	/// You don't need to do this for your own ScriptableObjects, which is why I separated it.
	/// You can just use [CreateAssetMenu] above your ScriptableObjectSingletons!
	/// </summary>
	internal static class CreationMenu
	{
		[UnityEditor.MenuItem(itemName: "Tools/CGTK/Samples/Singletons/Create ScriptableObject Singleton")]
		private static void CreateScriptableObjectSingleton()
		{
			ScriptableObjectCreator.Create<ExampleScriptableObjectSingleton>();
		}

		[UnityEditor.MenuItem(itemName: "Tools/CGTK/Samples/Singletons/Create ScriptableObject SingletonEnsured")]
		private static void CreateScriptableObjectSingletonEnsured()
		{
			ScriptableObjectCreator.Create<ExampleEnsuredScriptableObjectSingleton>();
		}
	}
}