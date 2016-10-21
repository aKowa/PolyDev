using UnityEngine;
using PolyDev.UI;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class UIController : MonoBehaviour
{
	private Binder<float> myTime;

	public void Start ()
	{
		myTime = new Binder<float>( this );	
	}

	public void Update ()
	{
		myTime.Value = (int)Time.time;
	}
}
