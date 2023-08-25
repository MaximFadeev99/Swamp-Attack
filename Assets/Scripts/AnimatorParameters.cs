using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    public static readonly int FireballExplosion = Animator.StringToHash(nameof(FireballExplosion));
    public static readonly int BushIdle = Animator.StringToHash(nameof(BushIdle));
    public static readonly int BushDisturbed = Animator.StringToHash(nameof(BushDisturbed));
    public static readonly int NinjaCast = Animator.StringToHash(nameof(NinjaCast));
    public static readonly int NinjaDie = Animator.StringToHash(nameof(NinjaDie));
    public static readonly int NinjaHurt = Animator.StringToHash(nameof(NinjaHurt));
    public static readonly int NinjaHurtWithKatana = Animator.StringToHash(nameof(NinjaHurtWithKatana));
    public static readonly int NinjaIdle = Animator.StringToHash(nameof(NinjaIdle));
    public static readonly int NinjaKatanaAttack = Animator.StringToHash(nameof(NinjaKatanaAttack));
    public static readonly int NinjaRun = Animator.StringToHash(nameof(NinjaRun));
    public static readonly int PlayerBlock = Animator.StringToHash(nameof(PlayerBlock));
    public static readonly int PlayerCast = Animator.StringToHash(nameof(PlayerCast));
    public static readonly int PlayerDie = Animator.StringToHash(nameof(PlayerDie));
    public static readonly int PlayerIdle = Animator.StringToHash(nameof(PlayerIdle));
    public static readonly int PlayerSwordAttack = Animator.StringToHash(nameof(PlayerSwordAttack));
    public static readonly int PlayerBowAttack = Animator.StringToHash(nameof(PlayerBowAttack));
}