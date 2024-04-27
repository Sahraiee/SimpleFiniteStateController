using System;


namespace SahraCore.Core.FSM
{
    public interface IFsmController<E> where E : Enum
    {
        FsmNode<E> CurrentState { get; }
        public E CurrentStateID { get; }

        void AddState(E id, Action onStateEnter = null, Action onStateExit = null, Action onStateStay = null);
        void AddState(FsmNode<E> _node);
        void AddOverrideState(FsmNode<E> _node);
        void RemoveState(FsmNode<E> _node);
        void ChangeState(E _stateID, bool allowToRepeate = false);
        void UpdateTask();
        void SetEnableStayTask(bool enableUpdateTask);
    }

}