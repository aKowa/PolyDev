using UnityEngine;
using UnityUI = UnityEngine.UI;

namespace PolyDev.UI
{
	public interface IType { }

	public class Text : UnityUI.Text, IType
	{
		public string text
		{
			get { return base.text; }
			set { base.text = value; }
		}
	}

	public class Image : UnityEngine.UI.Image, IType
	{
		public Sprite image
		{
			get { return base.sprite; }
			set { base.sprite = value; }
		}
	}
}
