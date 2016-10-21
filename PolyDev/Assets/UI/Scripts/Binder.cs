using System;
using UnityEngine;
using UnityEngine.UI;

namespace PolyDev.UI
{
	public class Binder<T>
	{
		private T value;
		private Text target;

		public Binder( Text newTarget )
		{
			target = newTarget;
		}

		public Binder( MonoBehaviour mono )
		{
			target = mono.GetComponent<Text> ();
			if ( target == null )
			{
				throw new NullReferenceException("There is no Text Component assigned to " + mono.name);
			}
		}

		public T Value
		{
			get { return value; }
			set
			{
				this.value = value;
				target.text = value.ToString();
			}
		}
	}
}
