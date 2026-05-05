using UnityEngine;

public sealed class DebugLogState : StateMachineBehaviour
{
    [SerializeField] private string stateName;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.LogFormat(this, "OnStateEnter '{0}'", stateName);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.LogFormat(this, "OnStateExit '{0}'", stateName);
    }
}
