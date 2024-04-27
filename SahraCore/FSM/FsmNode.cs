using System;

namespace SahraCore.FSM
{
    public class FsmNode<E> where E : Enum
    {
        public FsmNode(E id, Action onStateEnter = null, Action onStateExit = null, Action onStateStay = null)
        {
            ID = id;
            OnStateEnter = onStateEnter;
            OnStateExit = onStateExit;
            OnStateStay = onStateStay;
        }

        public E ID { get; private set; }


        /// <summary>
        /// the deligate that perform when entering to this node
        /// </summary>
        public Action OnStateEnter { get; private set; }


        /// <summary>
        /// the deligate that perform when exit from this node
        /// </summary>
        public Action OnStateExit { get; private set; }

        /// <summary>
        /// the deligate that perform every frame 
        /// </summary>
        public Action OnStateStay { get; private set; }

    }

}

