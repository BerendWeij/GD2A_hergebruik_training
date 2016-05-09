using UnityEngine;
using States;

public class FriendlyCharacter : MonoBehaviour {

    StateMachine behaviourMachine;

    void Awake()
    {
        behaviourMachine = new StateMachine(gameObject, StatesEnum.wander); 

        behaviourMachine.AddState(StatesEnum.wander, new Wander("Player", "", new Navigator()));
        behaviourMachine.AddState(StatesEnum.alert, new Charge("Player"));
        behaviourMachine.AddState(StatesEnum.intaract, new Attack("Player"));
        behaviourMachine.AddState(StatesEnum.retreat, new Flee("Player"));
        behaviourMachine.AddState(StatesEnum.idle, new Idle("Player"));

        behaviourMachine.Start();
    }

    void Update()
    {
        behaviourMachine.UpdateState();  
    }
}
