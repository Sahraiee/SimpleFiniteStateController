using System;
using System.Collections.Generic;
using UnityEngine;


namespace SahraCore.FSM
{

    public class FsmController<E> : IFsmController<E> where E :  Enum
    {

        /// <summary>
        /// the dictionary of othe FSM node
        /// </summary>
        private Dictionary<E, FsmNode<E>> _nodeDictionary;
        /// <summary>
        /// indicate the current state of the Object
        /// </summary>
        private FsmNode<E> _currentState;

        /// <summary>
        /// Allow to invoke the Update Task to run State Stay function
        /// </summary>
        private bool _enableStayTask;

        private FsmNode<E> currentState
        {
            get
            {
                return _currentState;
            }
            set
            {
                if (value == null)
                    return;

                //______________________ old state __________________________
                _currentState?.OnStateExit();
                //   Debug.Log(" OnState_Exit : " + _currentState.name);

                //______________________ new state __________________________

                _currentState = value; // change in this line

                _currentState?.OnStateEnter();

                //   Debug.Log(" OnState_Enter : " + _currentState.name);

                //if (_currentState.animationsClipHash > -1)
                //    ownerAnimator.CrossFade(_currentState.animationsClipHash, _currentState.animationCrossFade);
            }
        }

        /// <summary>
        /// return the current state
        /// </summary>
        /// <returns>FSM_NODE</returns>
        public FsmNode<E> CurrentState
        {
            get { return currentState; }
        }
        public E CurrentStateID
        {
            get { return currentState.ID; }
        }


#if ITICK_SYSTEM
        private ITickSystem _tickSystem;
        public FsmController(ITickSystem tickSystem)
#endif
        public FsmController()
        {
            _nodeDictionary = new Dictionary<E, FsmNode<E>>();
#if ITICK_SYSTEM
            _tickSystem = tickSystem;
            _tickSystem.Add_TickAction(UpdateTask);
#endif
        }

        public void Dispose()
        {
            _nodeDictionary.Clear();
#if ITICK_SYSTEM
            _tickSystem.Remove_TickAction(UpdateTask);
#endif
        }


        public void UpdateTask()
        {
            if (!_enableStayTask)
                return;

            _currentState.OnStateStay?.Invoke();
        }

        /// <summary>
        /// add one state to the  dictionary
        /// </summary>
        /// <returns></returns>
        public void AddState(FsmNode<E> _node)
        {
            if (!_nodeDictionary.ContainsKey(_node.ID))
            {
                _nodeDictionary.Add(_node.ID, _node);
                if (_currentState == null)
                    _currentState = _node;
            }
            else
                Debug.LogError("FSM Error ::  State < " + _node.ID + " > Exist in the Dictionary !!");
        }

        public void AddState(E id, Action onStateEnter = null, Action onStateExit = null, Action onStateStay = null)
        {
            FsmNode<E> node = new FsmNode<E>(id, onStateEnter, onStateExit, onStateStay);
            AddState(node);
        }

        /// <summary>
        /// u8sed to override an existing node.
        /// if not added previusly, then add it as a new state
        /// </summary>
        /// <param name="_node"></param>
        public void AddOverrideState(FsmNode<E> _node)
        {
            if (_nodeDictionary.ContainsKey(_node.ID))
            {
                _nodeDictionary[_node.ID] = _node;
            }
            else
            {
                _nodeDictionary.Add(_node.ID, _node);
            }
        }

        public void RemoveState(FsmNode<E> _node)
        {
            if (_nodeDictionary.Remove(_node.ID))
            {
                Debug.LogError("FSM  ::  State < " + _node.ID + " >Remove from Dictionary !!");
            }
            else
                Debug.LogError("FSM Error ::  State < " + _node.ID + " > Not Exist in the Dictionary !!");
        }

        /// <summary>
        /// this operation change the state to new one.first execute the previus
        /// OnState_Exit and the exexcute the OnState_Enter of the new state.if the new
        /// state's Special action is not null then exec the IEnumarator SpecialAction
        /// </summary>
        /// <returns></returns>
        public void ChangeState(E _stateID, bool allowToRepeate = false)
        {
            FsmNode<E> temp_currentState;
            if (_nodeDictionary.TryGetValue(_stateID, out temp_currentState))
            {
                if (!allowToRepeate)
                    if (currentState == temp_currentState)
                        return;
                currentState = temp_currentState;
            }
            else
            {
                Debug.LogError("Error :: FSM   >>     " + _stateID + "  Not exist in states  ");
            }
        }

        public void SetEnableStayTask(bool enableStayTask)
        {
            _enableStayTask = enableStayTask;
        }

    }

}