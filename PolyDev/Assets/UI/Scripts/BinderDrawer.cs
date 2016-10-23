using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PolyDev.UI
{
	[CustomPropertyDrawer( typeof (BindFloatToText) )]
	public class BinderDrawer : PropertyDrawer
	{
		private GameObject gameObj;
		private Component component;
		private int componentID;
		private string propertyName;
		private int propertyID;

		private const float fieldHeight = 16;

		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
		{
			EditorGUI.BeginProperty( position, label, property );

			// label
			var labelRect = new Rect( position.x, position.y, position.width, fieldHeight );
			EditorGUI.LabelField( labelRect, new GUIContent( property.type ) );
			
			// value
			var valueRect = new Rect ( position.x + 15, position.y + 5 + fieldHeight, position.width - 15, fieldHeight );
			EditorGUI.PropertyField( valueRect, property.FindPropertyRelative( "valueUnbound" ), new GUIContent("Value") );

			var objectRect = new Rect( position.x + 15, position.y + 10 + fieldHeight * 2, (position.width - 15)/ 3, fieldHeight );
			gameObj = (GameObject) EditorGUI.ObjectField( objectRect, GUIContent.none, gameObj,typeof (GameObject) );

			// component
			var componentRect = objectRect;
			componentRect.x += objectRect.width;
			var components = new Component[] { };
			string[] componentArray = {"Component"};
			if ( gameObj != null )
			{
				components = gameObj.GetComponents<Component>();
				componentArray = ConvertToStringArray( components );
			}
			componentID = EditorGUI.Popup( componentRect, componentID, componentArray );
			if ( gameObj != null )
			{
				component = components[componentID];
			}

			// property
			var propertyRect = componentRect;
			propertyRect.x += componentRect.width;
			string[] propertyArray = { "Property" };

			if ( component != null )
			{
				propertyArray = ConvertToStringArray( component.GetType().GetProperties() );
			}
			propertyID = EditorGUI.Popup ( propertyRect, propertyID, propertyArray );
			if ( component != null )
			{
				propertyName = propertyArray[propertyID];
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight( SerializedProperty property, GUIContent label )
		{
			return (fieldHeight + 5) * 3;
		}

		private string[] ConvertToStringArray<T>( IList<T> p )
		{
			var targetStringArray = new string[p.Count];
			for (int i = 0; i < p.Count; i++)
			{
				targetStringArray[i] = p[i].GetType ().ToString ();
			}
			return targetStringArray;
		}
	}
}
