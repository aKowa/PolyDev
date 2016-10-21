using System;
using JetBrains.Annotations;
using UnityEngine;

namespace PolyDev.UI
{
	public class Binder<T> where T : Component
	{
		private ValueType value;
		private T target;

		public Binder ( Component mono )
		{
			target = mono.GetComponent<T> ();
			if (target == null)
			{
				throw new NullReferenceException ( "There is no CanvasElement of type: " + typeof(T) +  " assigned to " + mono.name );
			}
		}

		public ValueType Value
		{
			get { return value; }
			set
			{
				this.value = value;

				if (typeof ( T ) == typeof ( Text ))
				{
					AssignText ();
				}
			}
		}

		private void AssignText()
		{
			var t = target as UnityEngine.UI.Text;
			if (t != null)
			{
				t.text = value.ToString ();
			}
		}
	}
}
