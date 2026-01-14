using UnityEngine;

public class PlayerSFXTriggers : MonoBehaviour
{
   public void AnimationSFX(int SFXToPlay)
   {
        AudioManager.Instance.PlaySFX(SFXToPlay);

   }
}
