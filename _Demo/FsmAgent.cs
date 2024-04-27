using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SahraCore.Core.FSM;

namespace SahraCore.FSM
{
	public enum EAgentState { Idle, Attack, Die}

	public class FsmAgent : MonoBehaviour
	{

		protected FsmController<EAgentState> _fsmController = new FsmController<EAgentState>();

		

		void Start()
		{
			_fsmController.AddState(EAgentState.Idle, OnIdleEnter, OnIdleExit,OnIdleStay);
			_fsmController.AddState(EAgentState.Attack, OnAttackEnter, OnAttackExit, OnAttackStay);
			_fsmController.AddState(EAgentState.Die, OnDieEnter, OnDieExit, OnDieStay);
		}

		void Update()
		{
			_fsmController.UpdateTask();
		}


		protected virtual void OnIdleEnter()
		{
			Debug.Log(" On Idle Enter");
		}
		protected virtual void OnIdleExit()
		{
			Debug.Log(" On Idle Exit");
		}
		protected virtual void OnIdleStay()
		{
			Debug.Log(" On Idle Stay");
		}


		protected virtual void OnAttackEnter()
		{
			Debug.Log(" On Attack Enter");
		}
		protected virtual void OnAttackExit()
		{
			Debug.Log(" On Attack Exit");
		}
		protected virtual void OnAttackStay()
		{
			Debug.Log(" On Attack Stay");
		}

		protected virtual void OnDieEnter()
		{
			Debug.Log(" On Die Enter");
		}
		protected virtual void OnDieExit()
		{
			Debug.Log(" On Die Exit");
		}
		protected virtual void OnDieStay()
		{
			Debug.Log(" On Die Stay");
		}
	}
}