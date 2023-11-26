using System.Collections;
using UnityEngine;

public class StrafeAction : MonoBehaviour, IPlayerAction
{
    private PlayerController _playerController;

    public void ExecuteAction(PlayerController playerController)
    {
        _playerController = playerController;
        Animator animator = playerController.GetComponent<Animator>();
        animator.SetTrigger("Strafe");
        AnimationClip clip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        float animationLength = clip.length;
        playerController.StartCoroutine(WaitForAnimation(animationLength));

       
    }
    private IEnumerator WaitForAnimation(float animationLength)
    {
        yield return new WaitForSeconds(animationLength);
        _playerController.CurrentAction = null;
    }
}
