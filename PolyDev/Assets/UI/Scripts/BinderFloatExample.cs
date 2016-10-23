using PolyDev.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent ( typeof ( Text ) )]
public class BinderFloatExample : MonoBehaviour
{
	public BindFloatToText myTime;

	public void Update ()
	{
		myTime.Value = (int)Time.time;
	}
}
