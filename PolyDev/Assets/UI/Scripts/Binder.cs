using System;
using System.Reflection;
using UnityEngine;

namespace PolyDev.UI
{
	public class Binder<TValue> 
	{
		public Component targetComponent;
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
				return propInfo = targetComponent.GetType ().GetProperty ( targetPropertyName );
			}
		}

		public Binder(){}
		
		public Binder( string targetPropertyName )
		{
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
			PropInfo.SetValue( this.targetComponent, Convert.ChangeType( this.valueUnbound, PropInfo.PropertyType ), null );
		}
	}
}
