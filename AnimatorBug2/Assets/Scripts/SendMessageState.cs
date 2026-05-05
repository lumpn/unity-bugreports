using UnityEngine;

public sealed class SendMessageState : StateMachineBehaviour
{
    [SerializeField] private string methodName;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(nameof(OnStateEnter), this);
        animator.gameObject.SendMessage(methodName, SendMessageOptions.RequireReceiver);
    }
}
