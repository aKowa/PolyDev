using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PolyDev.UI;

[RequireComponent(typeof(Text))]
public class UIController : MonoBehaviour
{
	//private Binder<float, Text> myTime;
	private Binder<States, Text> myStates;


	public void Start ()
	{
		//myTime = new Binder<float, Text>( this, "text" );
		myStates = new Binder<States, Text>( this, "text" );
		StartCoroutine( Wait() );
	}

	public void Update ()
	{
		//myTime.Value = (int)Time.time;
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds( 1 );
		switch ( myStates.Value )
		{
			case States.First:
				myStates.Value = States.Second;
				break;
			case States.Second:
				myStates.Value = States.Third;
				break;
			case States.Third:
				myStates.Value = States.First;
				break;
		}
		StartCoroutine( Wait() );
	}
}


public enum States
{
	First,
	Second,
	Third
}