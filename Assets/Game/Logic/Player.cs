using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public virtual void TurnUpdate()
	{}

	public virtual void Win()
	{}

	public virtual void Lose()
	{}
}
