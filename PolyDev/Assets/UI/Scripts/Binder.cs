using System;
using System.Reflection;
using UnityEngine;

namespace PolyDev.UI
{
	public class Binder<TValue,TTarget> where TTarget : Component
	{
		private TValue value;
		private readonly TTarget target;
		private readonly PropertyInfo propInfo;

		public Binder ( MonoBehaviour mono, string propertyName )
		{
			target = mono.GetComponent<TTarget> ();
			if (target == null)
			{
				throw new NullReferenceException ( "There is no CanvasElement of type: " + typeof(TTarget) +  " assigned to " + mono.name );
			}
			propInfo = target.GetType ().GetProperty ( propertyName );
		}




		public TValue Value
		{
			get { return value; }
			set
			{
				this.value = value;
				propInfo.SetValue( target, Convert.ChangeType( value, propInfo.PropertyType ), null );
			}
		}
	}
}
