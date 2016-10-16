using UnityEngine;
using System.Collections;

public class CallTest : MonoBehaviour
{
	private Test test = new Test();

	public void Start ()
	{
		Debug.Log( test.GetInt() );
	}
}
