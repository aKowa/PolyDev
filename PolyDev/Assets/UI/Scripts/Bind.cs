using System;
using System.Reflection;
using UnityEngine;

namespace PolyDev.UI
{
	public class Bind<TValue, TTarget> where TTarget : Component
	{
		[SerializeField] public GameObject targetGameObject;

		[SerializeField] public int componentID;
		[SerializeField] public Component targetComponent;
		public Component TargetComponent
		{
			get
			{
				if (targetComponent != null) { return targetComponent; }
				return targetComponent = targetGameObject.GetComponents<Component>()[componentID];
			}
		}
		
		[SerializeField] public int propertyID;
		private PropertyInfo propInfo;
		private PropertyInfo PropInfo
		{
			get
			{
				if ( propInfo != null) { return propInfo; }
				return propInfo = TargetComponent.GetType ().GetProperties ()[propertyID];
			}
		}

		public Bind(){}
		
		public Bind( GameObject newGameObject, string propertyName )
		{
			if (newGameObject == null) throw new NullReferenceException ("GameObject for property binding can not be null.");

			this.targetGameObject = newGameObject;
			this.targetComponent = this.targetGameObject.GetComponent<TTarget>() as Component;
			propInfo = this.targetComponent.GetType().GetProperty( propertyName );
		}

		public Bind( Component newTargetComponent, string propertyName )
		{
			if (newTargetComponent == null) throw new NullReferenceException ( "Comonent for property binding can not be null." );

			this.targetGameObject = newTargetComponent.gameObject;
			this.targetComponent = newTargetComponent;
			propInfo = this.targetComponent.GetType ().GetProperty ( propertyName );
		}


		[SerializeField] public TValue valueUnbound;
		public TValue Value
		{
			get { return valueUnbound; }
			set
			{
				this.valueUnbound = value;
				PropInfo.SetValue ( TargetComponent, Convert.ChangeType ( this.valueUnbound, PropInfo.PropertyType ), null );
			}
		}
	}
}
