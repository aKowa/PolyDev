using UnityEngine;
using PolyDev.UI;
using UnityEngine.UI;

namespace PolyDev.UI
{
	public class BindFloatToText : Binder<float, Text>
	{
		public BindFloatToText( MonoBehaviour mono, string propertyName )
		{
			base.SetParameter( mono, propertyName );
		}
	}
}
