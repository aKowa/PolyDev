using UnityEngine;
using UnityEditor;
using System;

public class GenericClass<T>
{
	public T value;
}

[System.Serializable]
public class DerivedClass : GenericClass<float>{}

[System.Serializable]
public class OtherDerivedClass : GenericClass<States>{}


[CustomPropertyDrawer ( typeof (DerivedClass) )]
[CustomPropertyDrawer(typeof(OtherDerivedClass))]
public class GenericDrawer : PropertyDrawer
{
	private GameObject obj;
	private Component[] components;
	private string[] componentNames = { "None" };
	private int index;

	private const float fieldHeight = 16;

	public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label )
	{
		EditorGUI.BeginProperty ( position, label, property );

		var width = position.width / 2;

		var labelRect = new Rect ( position.x, position.y, position.width, fieldHeight );
		//EditorGUI.LabelField ( labelRect, label );
		EditorGUI.PropertyField( labelRect, property.FindPropertyRelative( "value" ) );


		var objRect = new Rect ( position.x, position.y + fieldHeight, width, fieldHeight );

#pragma warning disable 618
		obj = (GameObject)EditorGUI.ObjectField ( objRect, GUIContent.none, obj, typeof ( GameObject ) );
#pragma warning restore 618

		if (obj != null)
		{
			components = obj.GetComponents<Component> ();
			componentNames = ConvertToStringArray ( components );
		}

		var unitRect = new Rect ( position.x + width, position.y + fieldHeight, width, fieldHeight );
		index = EditorGUI.Popup ( unitRect, index, componentNames );

		EditorGUI.EndProperty ();
	}

	// Convert a Component array to a string array
	private string[] ConvertToStringArray ( Component[] o )
	{
		var targetStringArray = new string[o.Length];
		for (int i = 0; i < o.Length; i++)
		{
			targetStringArray[i] = o[i].GetType ().ToString ();
		}
		return targetStringArray;
	}

	public override float GetPropertyHeight ( SerializedProperty property, GUIContent label )
	{
		return fieldHeight * 2;
	}
}
