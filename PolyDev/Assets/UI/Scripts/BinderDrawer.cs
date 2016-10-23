using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace PolyDev.UI
{
	[CustomPropertyDrawer( typeof (BindFloatToText) )]
	public class BinderDrawer : PropertyDrawer
	{
		private const float fieldHeight = 16;

		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
		{
			EditorGUI.BeginProperty( position, label, property );

			var target = property.serializedObject.targetObject;

			// label
			var labelRect = new Rect( position.x, position.y, position.width, fieldHeight );
			EditorGUI.LabelField( labelRect, new GUIContent( property.type ) );
			
			// value
			var valueRect = new Rect ( position.x + 15, position.y + 5 + fieldHeight, position.width - 15, fieldHeight );
			var serializedValue = property.FindPropertyRelative( "valueUnbound" );
			EditorGUI.PropertyField( valueRect, serializedValue, new GUIContent("Value") );

			// object
			var componentRect = new Rect ( position.x + 15, position.y + 10 + fieldHeight * 2, (position.width - 15) / 2, fieldHeight );
			var propertyRect = componentRect;
			propertyRect.x += componentRect.width;

			var serializedComponent = property.FindPropertyRelative( "targetComponent" );
			EditorGUI.PropertyField( componentRect, serializedComponent, GUIContent.none );
			var component = serializedComponent.objectReferenceValue as Component;

			string[] propertyNames = { "None" };
			if ( component != null )
			{
				propertyNames = GetNames( component.GetType().GetProperties() );
			}

			var serializedID = property.FindPropertyRelative( "propertyID" );
			serializedID.intValue = EditorGUI.Popup( propertyRect, serializedID.intValue, propertyNames );
			Debug.Log( "ID: " + serializedID.intValue );

			if ( GUI.changed )
			{
				EditorUtility.SetDirty( target );
			}

			/*
			gameObj = (GameObject) EditorGUI.ObjectField( objectRect, GUIContent.none, gameObj,typeof (GameObject) );

			// component
			var componentRect = objectRect;
			componentRect.x += objectRect.width;
			var components = new Component[] { };
			string[] componentArray = {"Component"};
			if ( gameObj != null )
			{
				components = gameObj.GetComponents<Component>();
				componentArray = GetTypeNames( components );
			}
			componentID = EditorGUI.Popup( componentRect, componentID, componentArray );
			if ( gameObj != null )
			{
				component = components[componentID];
				EditorUtility.SetDirty( target );
			}

			// property
			var propertyRect = componentRect;
			propertyRect.x += componentRect.width;
			string[] propertyArray = { "Property" };

			if ( component != null )
			{
				propertyArray = GetNames( component.GetType().GetProperties() );
			}

			propertyID = EditorGUI.Popup ( propertyRect, propertyID, propertyArray );
			if ( component != null )
			{
				propertyName = propertyArray[propertyID];
				EditorUtility.SetDirty ( target );
			}
			*/
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight( SerializedProperty property, GUIContent label )
		{
			return (fieldHeight + 5) * 3;
		}

		private string[] GetTypeNames<T>( IList<T> list )
		{
			var targetStringArray = new string[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				targetStringArray[i] = list[i].GetType ().ToString ();
			}
			return targetStringArray;
		}

		private string[] GetNames<T> ( IList<T> list )
		{
			var targetStringArray = new string[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				targetStringArray[i] = list[i].ToString ();
			}
			return targetStringArray;
		}
	}
}
