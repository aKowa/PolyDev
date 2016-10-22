using System;
using System.Reflection;
using UnityEngine;

namespace PolyDev.UI
{
	/// <summary>
	/// Binder class.
	/// </summary>
	/// <typeparam name="TValue">Value type.</typeparam>
	/// <typeparam name="TTarget">Type of target Component.</typeparam>
	[System.Serializable]
	public class Binder<TValue,TTarget> where TTarget : Component
	{
		private readonly TTarget target;
		private readonly PropertyInfo propInfo;

		/// <summary>
		/// Constructs Binder object.
		/// </summary>
		/// <param name="mono">Behavior that has the target Component attached. </param>
		/// <param name="propertyName">The name of the property that should be bound to this value.</param>
		public Binder ( MonoBehaviour mono, string propertyName )
		{
			target = mono.GetComponent<TTarget> ();
			if (target == null)
			{
				throw new NullReferenceException ( "There is no CanvasElement of type: " + typeof(TTarget) +  " assigned to " + mono.name );
			}
			propInfo = target.GetType ().GetProperty ( propertyName );
		}

		/// <summary>
		/// Value Field, which updates bound Component property in Setter.
		/// </summary>
		public TValue Value
		{
			get { return ValueUnbound; }
			set
			{
				this.ValueUnbound = value;
				UpdateBoundProperty();
			}
		}

		/// <summary>
		/// Updates the bound property to this value.
		/// </summary>
		public void UpdateBoundProperty()
		{
			propInfo.SetValue ( target, Convert.ChangeType ( this.ValueUnbound, propInfo.PropertyType ), null );
		}

		/// <summary>
		/// Gets and Sets value without updating the bound property. Note: Use UpdateBoundProperty() to do so.
		/// </summary>
		public TValue ValueUnbound { get; set; }
	}
}
