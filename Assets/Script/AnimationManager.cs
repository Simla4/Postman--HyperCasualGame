using UnityEngine;

public class AnimationManager : MonoSingleton<AnimationManager>
{
    public void ChangeAnimation(GameObject unit, string trigger)
    {
        unit.GetComponent<Animator>().SetTrigger(trigger);

    }
}

public enum PlayerAnimations
{
    Idle,
    Running,
}