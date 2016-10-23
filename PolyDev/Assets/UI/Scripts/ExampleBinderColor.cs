using UnityEngine;
using UnityEngine.UI;
using PolyDev.UI;

[RequireComponent(typeof(Image))]
public class ExampleBinderColor : MonoBehaviour
{
	public Binder<Color> myColor;

	public void Start ()
	{
		myColor = new Binder<Color>( "color" );
	}

	public void Update ()
	{
		var t = Mathf.Abs( Mathf.Sin( Time.time ) );
		myColor.Value = Color.Lerp( Color.red, Color.yellow, t );
	}
}
