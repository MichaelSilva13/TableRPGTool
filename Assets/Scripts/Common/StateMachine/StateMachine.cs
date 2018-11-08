using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

	protected State currentState;
	public virtual State CurrentState
	{
		get { return currentState; }
		set { Transition(value); }

	}

	protected bool inTransition;

	public virtual T GetState<T>() where T : Component
	{
		T target = GetComponent<T>();
		if (target == null)
			target = gameObject.AddComponent<T>();
		return target;
	}

	public virtual void ChangeState<T>() where T : State
	{
		CurrentState = GetState<T>();
	}

	protected virtual void Transition(State s)
	{
		if(currentState==s || inTransition)
			return;
		
		inTransition = true;

		if (currentState != null) 
			currentState.Exit();

		currentState = s;
		
		if(currentState!=null)
			currentState.Enter();

		inTransition = false;
	}
}
