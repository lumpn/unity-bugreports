# Bug description
Animation Clips get prematurely abandoned by the Animator Controller and don't play to the end, leaving animated properties in an intermediate state.

## How to reproduce
Play the SampleScene in editor or Build and Run a standalone Windows player.

## Expected result
You should see a black rectangle fading to white and finally disappearing, leaving only the blue background.

## Actual result
The rectangle remains visible when white and never disappears.

## Details
Open the `Assets/Animations/Transition.anim` animation clip and move the "TriggerHitch" event from frame 55 to frame 40. Hit play again. This time the white rectangle disappears. Move the "TriggerHitch" event back to frame 55, the rectangle stays.

Open the `Assets/Scripts/HitchHelper.cs` script that listens to the "TriggerHitch" event and see that it does absolutely nothing that should affect the UI rectangle; all it does is cause a hitch on the main thread. In the `Assets/Scenes/SampleScene.unity` scene, go to `Canvas/Image/HitchHelper` and set the "Hitch Duration" to `0`. The bug disappears. Set it to `0.1`, the bug reappears. Delete the "TriggerHitch" event, the bug disappears.

It seems that the bug happens when there's a hitch on the main thread that causes frame 58 of the animation to get skipped. Subsequently the Image component never gets disabled. Also the color of the rectangle never reaches pure white. It seems that the Animator is abandoning the unfinished "Transition" animation clip and prematurely moves on to the next animation state.

As a user, I would expect my animation clips to finish playing, I would expect my bools to toggle reliably, and I would expect my animation clip events to fire reliably, always, not just when the frame rate is high enough to sample each and every frame in a clip.

# Unity's response
```By design```
I have decided that this behavior is by design due to how the Animator handles game lag and animated properties. When a heavy frame drop occurs, the Animator skips frames to catch up, meaning events placed at the very end of a clip can simply be missed. Because of this, Animation Events are intended more for secondary, cosmetic effects (like triggering sound effects or visual particles) rather than critical game logic. Additionally, because the animation clip is actively controlling the UI Image, the Animator will automatically override any outside scripts that try to change it during a transition.

Workaround: For reliable logic, I would recommend using a StateMachineBehaviour script attached to your Animator state instead of standard Animation Events. You can use the OnStateExit function to disable the entire GameObject (using `gameObject.SetActive(false)`) rather than just the Image component. This guarantees the object turns off exactly when the animation state finishes and stops the Animator from overriding your script.

# Additional notes
This bug report is not about Animation Events. I understand that Animation Events are unreliable and get skipped when a frame drop occurs, but this is not that.

The bug I’m presenting here, as stated, is that a `bool` property animated by an animation clip does not get set to its final value. Additionally, the color property animated by the same animation clip does not get set to its final value either. The entire clip simply gets abandoned before it has finished playing.

# References
- https://docs.unity3d.com/Manual/class-Animator.html
- https://docs.unity3d.com/Manual/StateMachineBasics.html
- https://docs.unity3d.com/Manual/StateMachineBehaviours.html
- https://docs.unity3d.com/Manual/script-AnimationWindowEvent.html
- https://docs.unity3d.com/ScriptReference/AnimationEvent.html
