using UnityEngine;
using UnityEngine.UI;

namespace PolyDev.UI
{
	[System.Serializable]
	public class BindFloatToText : Binder<float>
	{
		public int propertyID;

		public BindFloatToText( string targetPropertyName )
		{
			base.targetPropertyName = targetPropertyName;
		}
	}
}
