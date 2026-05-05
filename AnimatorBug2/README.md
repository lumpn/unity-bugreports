# Bug description
Animation Clips assume control over the properties they animate and don't let scripts change the value of said properties, even if the animation clip never plays.

## How to reproduce
Play the SampleScene in editor or Build and Run a standalone Windows player.

## Expected result
You should see a black rectangle fading to white and finally disappearing, leaving only the blue background.

## Actual result
The rectangle remains visible when white and never disappears.
