# Colored Damage Types


Colored Damage Types changes the tooltip and damage text of weapons to be colored, so that it's easier to quickly tell what kind of damage the weapon deals at a glance.

It is completely customizable via the mod config menu, but the default colors are as follows:

Melee: Red

Ranged: Green

Magic: Blue

Thrown: Brown

Summon: Pink

Sentries: Purple

## Cross-Mod Compatibility

This mod also supports custom [DamageClass](https://docs.tmodloader.net/html_alpha/class_terraria_1_1_mod_loader_1_1_damage_class.html) classes added by other mods by using the [Mod.Call](https://github.com/tModLoader/tModLoader/wiki/Expert-Cross-Mod-Content) function!

To add support for your own mod's damage type, you simply need to reference my mod and call the following:
```cs
Mod.Call(DamageClass DamageClassToBeAdded, Color TooltipColor, Color DamageColor, Color CritDamageColor)

//Alternatively, the rgb values can simply be passed as a tuple.
//First tuple is Tooltip color, 2nd is damage color, 3rd is crit damage color:

Mod.Call("AddDamageType", DamageClass DamageClassToBeAdded, int r1, int g1, int b1), (int r2, int g2, int b2), (int r3, int g3, int b3))
```

Example of how you would do it:
```cs
if (ModLoader.TryGetMod("ColoredDamageTypes", out Mod coloreddamagetypes))
{
	//Color version
	coloreddamagetypes.Call("AddDamageType", ModContent.GetInstance<ExampleDamageClass>(), new Color(255, 210, 88), new Color(160, 155, 70), new Color(255, 165, 120));

	//Tuple version
	coloreddamagetypes.Call("AddDamageType", ModContent.GetInstance<AnotherExampleDamageClass>(), (255, 30, 88), (50, 155, 70), (255, 165, 120)); 
}
```