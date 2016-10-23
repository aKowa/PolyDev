using UnityEngine;
using UnityEngine.UI;
using PolyDev.UI;

[RequireComponent(typeof(Image))]
public class BinderColorExample : MonoBehaviour
{
	public Binder<Color, Image> myColor;

	public void Start ()
	{
		myColor = new Binder<Color, Image>( this.gameObject, "color" );
	}

	public void Update ()
	{
		var t = Mathf.Abs( Mathf.Sin( Time.time ) );
		myColor.Value = Color.Lerp( Color.red, Color.yellow, t );
	}
}
