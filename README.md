# Unity bug reports
Bug reports with reproduction steps sent to Unity.

## Animator
[Animation Clips get prematurely abandoned](AnimatorBug) by the Animator Controller and don't play to the end, leaving animated properties in an intermediate state.

[Animation Clips assume control](AnimatorBug2) over the properties they animate and don't let scripts change the value of said properties, even if the animation clip never plays.

# Rationale
I've decided to make my bug reports public, especially those deemed "By Design" or "Won't Fix" so that there is a public record of pitfalls I encountered. May it help you avoid the same pitfalls.

If you would like to contribute, upload your reproduction case to a public repository and send me the address. I will link to it here.
