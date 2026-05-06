# Bug description
Animation Clips assume control over the properties they animate and don't let scripts change the value of said properties, even if the animation clip never plays.

## How to reproduce
Play the SampleScene in editor or Build and Run a standalone Windows player.

## Expected result
You should see a black rectangle fading to white and finally disappearing, leaving only the blue background.

## Actual result
The rectangle remains visible when white and never disappears.

## Details
Open the `Assets/Animations/Animator.controller` animator controller and clear the "Motion" field in the "Unused" state. Rerun the experiment. The white rectangle now disappears.

As the user, I expect animation clips to assume control of the properties they animate and to overwrite any values I'm setting via scripts while the clip is playing. However, I expect animation clips to relinquish control once they are done playing. Moreover I expect animation clips that never play to have no effect nor side effect.

# Unity's response
    By Design

To track the properties that an Animator must write to, the Animator Component builds an internal collection of bindings. Each binding is built from the EditorCurveBinding of each AnimationClip associated with the Animator through assets and custom graphs, even if the animation state is disconnected. To maintain determinism, the Animator takes control of these bound properties and evaluates them every frame. Because standard scripts execute during the `Update()` loop and the internal Animator evaluates immediately afterward, the Animator will instantly overwrite your script's changes before the frame is rendered. Moving your logic to `LateUpdate()` loop will fix your issue.

# Additional notes
None of the scripts in the bug report use the `Update()` method.

# References
- https://docs.unity3d.com/Manual/class-Animator.html
- https://docs.unity3d.com/Manual/class-AnimatorController.html
- https://docs.unity3d.com/Manual/AnimationClips.html
- https://docs.unity3d.com/Manual/animeditor-AnimationCurves.html
