using UnityEngine;
using System.Collections;

public class Behavior : MonoBehaviour
{
	private MyClass myClass = new MyClass();

	public void Start ()
	{
		Debug.Log( myClass.GetInt() );
	}
}
