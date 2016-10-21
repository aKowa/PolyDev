using UnityEngine;
using UnityEngine.UI;
using PolyDev.UI;

[RequireComponent(typeof(Text))]
public class UIController : MonoBehaviour
{
	private Binder<float, Text> myTime;

	public void Start ()
	{
		myTime = new Binder<float, Text>( this );
	}

	public void Update ()
	{
		myTime.Value = (int)Time.time;
	}
}
