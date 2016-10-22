using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;
using System;
using System.Reflection;
using System.Reflection.Emit;

public class GenericClass<T>
{
	public T variable;
}


[System.Serializable]
public class DerivedClass
{
	public ValueType value;
	public Component component;
	public States states;
}


[CustomPropertyDrawer ( typeof ( DerivedClass ) )]
public class GenericDrawer : PropertyDrawer
{
	private GameObject obj;
	private Component component;
	private Component[] components;
	private string[] componentNames;
	private int index = 0;

	public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
	{
		EditorGUI.BeginProperty( position, label, property );
		
		var objRect = new Rect ( position.x, position.y, 90, position.height );
		obj = (GameObject)EditorGUI.ObjectField ( objRect, GUIContent.none, obj, typeof ( GameObject ) );

		if ( obj != null )
		{
			components = obj.GetComponents<Component>();
			componentNames = new string[components.Length];
			for ( int i = 0; i < componentNames.Length; i++ )
			{
				componentNames[i] = components[i].GetType().ToString();
			}

			EditorGUILayout.Popup ( index, componentNames );
			component = components[index];
		}

		//var componentRect = new Rect ( position.x + 95, position.y, 90, position.height );
		//EditorGUI.EnumPopup( componentRect, components );

		EditorGUI.EndProperty ();
	}
}
