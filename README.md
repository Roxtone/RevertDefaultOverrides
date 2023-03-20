# Revert Default Overrides
Reverts Game Object, Transform and Rect transform overrides that are created by default when creating a new prefab instance in edit mode.

## Installation
Install via _Add package from git URL_ in the Package Manager.

## Basic Usage

Create a new instance of a prefab. Its default overrides will be automatically reverted. Read more about default overrides at [Unity Documentation - Is Default Override](https://docs.unity3d.com/ScriptReference/PrefabUtility.IsDefaultOverride.html).

Overrides will not be reverted while pressing the Ctrl key (only works with the new Input System) - this can be useful for duplicating game objects with Ctrl + D or placing them in the scene view.

Preferences can be accessed with Edit/Preferences: Revert Default Overrides with one checkbox per override.