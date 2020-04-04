# Unity-Rigidbody-Wind-Zones

## RigidbodyWindZone Component

Uses Physics.BoxOverlap() or Physics.SphereOverlap to fetch all rigidbodies in a specific zone.
Then it applies continous force to those rigidbodies based on perlin noise.
Parameters like the turbulence, windStrength, zone shape, etc. should exposed to the user.
