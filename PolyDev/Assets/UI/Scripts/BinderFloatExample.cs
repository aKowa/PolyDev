using UnityEngine;
using UnityEngine.UI;
using PolyDev.UI;

[RequireComponent(typeof(Text))]
public class BinderFloatExample : MonoBehaviour
{
	public Binder<float, Text> myTime;

	public void Start ()
	{
		myTime = new Binder<float, Text>( this, "text" );
	}

	public void Update ()
	{
		myTime.Value = (int)Time.time;
	}
}