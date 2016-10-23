using System;
using System.Reflection;
using UnityEngine;

namespace PolyDev.UI
{
	public class Binder<TValue, TComponent> where TComponent : Component
	{
		public GameObject targetGameObject;

		private TComponent targetComponent;
		protected TComponent TargetComponent
		{
			get
			{
				if (targetComponent != null)
				{
					return targetComponent;
				}
				return targetComponent = targetGameObject.GetComponent<TComponent> ();
			}
		}

		public string targetPropertyName;
		private PropertyInfo propInfo;
		protected PropertyInfo PropInfo
		{
			get
			{
				if (propInfo != null)
				{
					return propInfo;
				}
				return propInfo = TargetComponent.GetType ().GetProperty ( targetPropertyName );
			}
		}

		public Binder(){}
		
		public Binder( GameObject targetGameObject, string targetPropertyName )
		{
			this.targetGameObject = targetGameObject;
			this.targetPropertyName = targetPropertyName;
		}

		public TValue valueUnbound;
		public TValue Value
		{
			get { return valueUnbound; }
			set
			{
				this.valueUnbound = value;
				UpdateBoundProperty();
			}
		}

		public void UpdateBoundProperty()
		{
			PropInfo.SetValue( this.TargetComponent, Convert.ChangeType( this.valueUnbound, PropInfo.PropertyType ), null );
		}
	}
}
