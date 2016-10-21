using System;
using UnityEngine;
using UnityEngine.UI;

namespace PolyDev.UI
{
	public class Binder<TValue,TTarget> where TTarget : Component
	{
		private TValue value;
		private TTarget target;

		public Binder ( MonoBehaviour mono )
		{
			target = mono.GetComponent<TTarget> ();
			if (target == null)
			{
				throw new NullReferenceException ( "There is no CanvasElement of type: " + typeof(TTarget) +  " assigned to " + mono.name );
			}
		}

		public TValue Value
		{
			get { return value; }
			set
			{
				this.value = value;

				if (typeof ( TTarget ) == typeof ( Text ))
				{
					AssignText ();
				}
			}
		}

		private void AssignText()
		{
			var t = target as Text;
			if (t != null)
			{
				t.text = value.ToString ();
			}
		}
	}
}
