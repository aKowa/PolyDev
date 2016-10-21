using UnityEngine;
using UnityUI = UnityEngine.UI;
using PolyDev.UI;

[RequireComponent(typeof(UnityUI.Text))]
public class UIController : MonoBehaviour
{
	private Binder<Text> myTime;

	public void Start ()
	{
		myTime = new Binder<Text>( this );	
	}

	public void Update ()
	{
		myTime.Value = (int)Time.time;
	}
}
