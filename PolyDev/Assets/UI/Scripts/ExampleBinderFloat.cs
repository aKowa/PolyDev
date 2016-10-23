using PolyDev.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent ( typeof ( Text ) )]
public class ExampleBinderFloat : MonoBehaviour
{
	public BindFloatToText myTime;

	public void Start()
	{
		//myTime = new BindFloatToText( this.gameObject, "text" );
	}

	public void Update ()
	{
		myTime.Value = (int)Time.time;
	}
}
