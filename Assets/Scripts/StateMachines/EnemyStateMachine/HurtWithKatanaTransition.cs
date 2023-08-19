public class HurtWithKatanaTransition : HurtTransition
{
    public override bool IsConditionMet()
    {
        if (KatanaAttackState.IsAttakingWithKatana == true && IsHurt)
        {
            IsHurt = false;
            return true;
        }
        else
        {
            IsHurt = false;
            return false;
        }
    }
}
