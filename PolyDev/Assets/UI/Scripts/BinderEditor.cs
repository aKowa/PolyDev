using UnityEngine;
using UnityEditor;


namespace PolyDev.UI
{
	[CanEditMultipleObjects]
	[CustomEditor( typeof (BinderEditor) )]
	public class BinderEditor : Editor
	{
		private SerializedProperty test;

		private void OnEnable()
		{
			test = serializedObject.FindProperty( "value" );
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField( test, new GUIContent( "Test" ) );
		}
	}
}
