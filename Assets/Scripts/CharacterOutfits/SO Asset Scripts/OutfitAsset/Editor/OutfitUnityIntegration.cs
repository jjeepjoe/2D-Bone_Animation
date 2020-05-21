using UnityEngine;
using UnityEditor;

static class OutfitUnityIntegration 
{
	[MenuItem("Assets/Create/OutfitAsset")]
	public static void CreateYourScriptableObject() {
        ScriptableObjectUtility2.CreateAsset<OutfitAsset>();
	}
}
