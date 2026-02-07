# Open-World City Driving (Desktop, Unity URP/HDRP)

This repository contains a **phase-based, modular AAA-style 3D open-world city driving game** foundation in Unity (C#). The architecture is built around the **Manager pattern**, **ScriptableObject configs**, **event-driven messaging**, **object pooling**, and **async-ready** systems.

> **Rendering Pipeline:** URP or HDRP (choose one during Unity project setup).  
> **Platforms:** Desktop only.  
> **Assets:** No paid assets required.

---

## Project Structure (Clean Folder Layout)
```
Assets/
  Scripts/
    Core/
    Input/
    Save/
    Settings/
    Vehicles/
    Cameras/
    City/
    Traffic/
    Law/
    Missions/
    Garage/
    Economy/
    Weather/
    Multiplayer/
    UI/
    Audio/
    Performance/
    Tooling/Editor/
    Shared/
    ScriptableObjects/
```

---

## Global Build Rules (Applied to Every Phase)
- Build in **phases** that compile independently.
- Use **modular architecture** with **Manager pattern** and a shared **GameEventBus**.
- Store tunables in **ScriptableObject** configs.
- Use **event-driven messaging** to avoid tight coupling.
- Use **object pooling** for runtime instantiation-heavy systems.
- Prefer **async loading** (scene streaming, city chunks, replay buffers).
- Expose **Inspector tuning variables** for designers.
- Provide **prefab wiring** and **scene setup** steps.
- No paid assets required.

---

## PHASE GROUP A — CORE FOUNDATION

### A1 — Boot System
**Scripts**
- `BootstrapManager`
- `GameBootstrapConfig` (ScriptableObject)

**Folder Placement**
- `Assets/Scripts/Core/BootstrapManager.cs`
- `Assets/Scripts/ScriptableObjects/GameBootstrapConfig.cs`

**Prefab Components List**
- Boot Scene GameObject: `Bootstrap`
  - `BootstrapManager`

**Scene Wiring Steps**
1. Create a **Boot** scene.
2. Add empty GameObject `Bootstrap`.
3. Add `BootstrapManager`.
4. Create a `GameBootstrapConfig` asset.
5. Add manager type names in order (e.g., `OpenWorldDriving.InputSystem.InputManager`).

**Inspector Values**
- `BootstrapManager.bootstrapConfig`: assign the `GameBootstrapConfig` asset.

**Test Procedure**
- Press Play. Confirm `Boot` loads and `VehicleTest` loads afterward.

### A2 — Input System
**Scripts**
- `InputManager`
- `InputBindingsSO`

**Folder Placement**
- `Assets/Scripts/Input/InputManager.cs`
- `Assets/Scripts/ScriptableObjects/InputBindingsSO.cs`

**Prefab Components List**
- Persistent Manager: `InputManager` attached under `PersistentManagers` root.

**Scene Wiring Steps**
1. Create `InputBindingsSO` asset.
2. Add default bindings (e.g., `CameraThirdPerson` -> `Alpha1`, etc.).
3. Assign to `InputManager`.

**Inspector Values**
- `InputManager.cameraToggleActions`: leave default.

**Test Procedure**
- Press toggle keys. Ensure events fire and camera changes if rigs are wired.

### A3 — Save Framework
**Scripts**
- `SaveManager`
- `SettingsManager`

**Folder Placement**
- `Assets/Scripts/Save/SaveManager.cs`
- `Assets/Scripts/Settings/SettingsManager.cs`

**Prefab Components List**
- Persistent Manager: `SaveManager`
- Persistent Manager: `SettingsManager`

**Scene Wiring Steps**
1. Attach `SaveManager` under `PersistentManagers`.
2. Attach `SettingsManager` and assign `SaveManager`.

**Inspector Values**
- `SettingsManager.activeProfileSlot`: `0`.

**Test Procedure**
- Update a setting via debug UI and call `SaveSettings()`.

---

## PHASE GROUP B — VEHICLE PLATFORM

**Scripts**
- `CarController`
- `VehiclePhysicsModel`
- `WheelModule`
- `DrivetrainModule`
- `VehicleStatsSO`

**Folder Placement**
- `Assets/Scripts/Vehicles/*.cs`
- `Assets/Scripts/ScriptableObjects/VehicleStatsSO.cs`

**Prefab Components List**
- Vehicle prefab
  - `Rigidbody`
  - `CarController`
  - `VehiclePhysicsModel`
  - `DrivetrainModule`
  - `WheelModule` (per wheel)
  - `WheelCollider` (per wheel)

**Scene Wiring Steps**
1. Create `VehicleStatsSO` assets for each class (Sports/SUV/etc.).
2. Assign stats to `CarController` and `VehiclePhysicsModel`.
3. Hook `WheelModule` array in `CarController`.

**Inspector Values**
- `VehicleStatsSO.maxTorque`: ~400
- `VehicleStatsSO.brakeTorque`: ~2000
- `VehiclePhysicsModel.antiRollStrength`: ~5000

**Test Procedure**
- Create **VehicleTest** scene with a plane and a vehicle prefab. Confirm it drives.

---

## PHASE GROUP C — CAMERA STACK

**Scripts**
- `CameraManager`
- `CameraRigBase`
- `FollowRig`
- `CockpitRig`
- `ReplayRecorder`

**Folder Placement**
- `Assets/Scripts/Cameras/*.cs`

**Prefab Components List**
- `CameraManager` (manager)
- `FollowRig` / `CockpitRig` rigs with Camera components

**Scene Wiring Steps**
1. Create camera rigs and assign them to `CameraManager`.
2. Assign player vehicle as target.
3. Bind camera toggle actions to Input.

**Inspector Values**
- `FollowRig.offset`: `(0,3,-6)`

**Test Procedure**
- Toggle camera hotkeys to switch rigs.

---

## PHASE GROUP D — CITY WORLD SYSTEM

**Scripts**
- `CityGenerator`
- `DistrictManager`
- `RoadSplineBuilder`
- `BuildingSpawner`
- `WorldStreamer`

**Folder Placement**
- `Assets/Scripts/City/*.cs`

**Prefab Components List**
- `CityGenerator` root
  - `DistrictManager`
  - `RoadSplineBuilder`
  - `BuildingSpawner`
  - `WorldStreamer`

**Scene Wiring Steps**
1. Create city root GameObject.
2. Add the components above.
3. Assign chunks to `WorldStreamer`.

**Inspector Values**
- `WorldStreamer.loadDistance`: `500`

**Test Procedure**
- Move player and confirm chunks activate/deactivate.

---

## PHASE GROUP E — TRAFFIC SIMULATION

**Scripts**
- `TrafficManager`
- `TrafficAgentAI`
- `LaneGraph`
- `SignalController`

**Folder Placement**
- `Assets/Scripts/Traffic/*.cs`

**Prefab Components List**
- `TrafficManager` manager
- `TrafficAgentAI` prefab

**Scene Wiring Steps**
1. Create `LaneGraph` with node transforms.
2. Assign to traffic agents.

**Inspector Values**
- `TrafficManager.maxAgents`: `50`

**Test Procedure**
- Spawn agents and verify they loop nodes.

---

## PHASE GROUP F — LAW & POLICE SYSTEM

**Scripts**
- `WantedSystem`
- `PoliceManager`
- `PoliceAI`
- `ViolationDetector`

**Folder Placement**
- `Assets/Scripts/Law/*.cs`

**Prefab Components List**
- `PoliceAI` prefab
- `ViolationDetector` on player vehicle

**Scene Wiring Steps**
1. Assign `WantedSystem` to `ViolationDetector`.
2. Provide `PoliceManager` with a police prefab.

**Inspector Values**
- `ViolationDetector.speedLimit`: `25`

**Test Procedure**
- Exceed speed limit and confirm wanted level increases.

---

## PHASE GROUP G — MISSIONS & STORY ENGINE

**Scripts**
- `MissionManager`
- `MissionGraph`
- `MissionBase`
- `ObjectiveNode`
- `DialogueSystem`
- `NPCInteraction`

**Folder Placement**
- `Assets/Scripts/Missions/*.cs`
- `Assets/Scripts/ScriptableObjects/MissionGraph.cs`

**Prefab Components List**
- `NPCInteraction` with `DialogueSystem`

**Scene Wiring Steps**
1. Create a `MissionGraph` asset.
2. Assign to a custom `MissionBase` implementation.

**Test Procedure**
- Trigger NPC interaction and accept mission.

---

## PHASE GROUP H — GARAGE & CUSTOMIZATION

**Scripts**
- `GarageManager`
- `CustomizationSystem`
- `UpgradeSystem`
- `UpgradeDataSO`

**Folder Placement**
- `Assets/Scripts/Garage/*.cs`
- `Assets/Scripts/ScriptableObjects/UpgradeDataSO.cs`

**Prefab Components List**
- Garage UI root
  - `CustomizationSystem`
  - `UpgradeSystem`

**Scene Wiring Steps**
1. Assign vehicle renderers to `CustomizationSystem`.
2. Create `UpgradeDataSO` assets and assign to `UpgradeSystem`.

**Test Procedure**
- Apply paint and upgrade a vehicle stat.

---

## PHASE GROUP I — ECONOMY & PROGRESSION

**Scripts**
- `EconomyManager`
- `ProgressionManager`
- `SkillTreeSystem`

**Folder Placement**
- `Assets/Scripts/Economy/*.cs`

**Prefab Components List**
- Persistent Manager: `EconomyManager`
- Persistent Manager: `ProgressionManager`
- Persistent Manager: `SkillTreeSystem`

**Scene Wiring Steps**
1. Attach `EconomyManager`, `ProgressionManager`, and `SkillTreeSystem` under `PersistentManagers`.
2. Wire `EconomyManager` to UI widgets (wallet, rewards).

**Inspector Values**
- `EconomyManager.startingCurrency`: `5000`
- `ProgressionManager.startingLevel`: `1`

**Test Procedure**
- Award XP and currency; verify level-ups.

---

## PHASE GROUP J — DAY NIGHT WEATHER

**Scripts**
- `DayNightSystem`
- `WeatherManager`
- `LightingProfileSO`

**Folder Placement**
- `Assets/Scripts/Weather/*.cs`
- `Assets/Scripts/ScriptableObjects/LightingProfileSO.cs`

**Scene Wiring Steps**
1. Create `LightingProfileSO` asset.
2. Assign gradients and curve.
3. Assign directional light.

**Test Procedure**
- Run scene and confirm lighting changes over time.

---

## PHASE GROUP K — MULTIPLAYER (Netcode for GameObjects)

**Scripts**
- `MultiplayerManager`
- `LobbyManager`
- `NetworkVehicle`
- `NetworkRaceManager`

**Folder Placement**
- `Assets/Scripts/Multiplayer/*.cs`

**Prefab Components List**
- `MultiplayerManager` (manager)
- `LobbyManager` (manager)
- `NetworkVehicle` (on vehicle prefab)
- `NetworkRaceManager` (manager)

**Setup Steps**
1. Install **Unity Netcode for GameObjects** from Package Manager.
2. Define `UNITY_NETCODE` scripting define symbol.
3. Implement NetworkBehaviour logic in provided scripts.

**Scene Wiring Steps**
1. Add `MultiplayerManager` and `LobbyManager` under `PersistentManagers`.
2. Add `NetworkVehicle` to the player vehicle prefab and register it with `NetworkManager`.

**Inspector Values**
- `NetworkVehicle.syncRate`: `30`
- `LobbyManager.maxPlayers`: `16`

**Test Procedure**
- Start a host session and connect a client.

---

## PHASE GROUP L — UI FRAMEWORK

**Scripts**
- `UIManager`
- `HUDSystem`
- `MinimapSystem`
- `GPSNavigator`

**Folder Placement**
- `Assets/Scripts/UI/*.cs`

**Prefab Components List**
- `UIManager` (manager)
- `HUDSystem` on HUD canvas
- `MinimapSystem` on minimap camera
- `GPSNavigator` on UI navigation root

**Scene Wiring Steps**
1. Create HUD canvas.
2. Assign widgets to `HUDSystem`.

**Inspector Values**
- `HUDSystem.speedText`: assign TMP_Text reference
- `HUDSystem.rpmText`: assign TMP_Text reference

**Test Procedure**
- Update HUD speed/RPM via script and confirm UI updates.

---

## PHASE GROUP M — AUDIO ENGINE

**Scripts**
- `AudioManager`
- `EngineAudioController`
- `AmbientZoneSystem`

**Folder Placement**
- `Assets/Scripts/Audio/*.cs`

**Prefab Components List**
- `AudioManager` (manager)
- `EngineAudioController` on vehicle prefab
- `AmbientZoneSystem` on zone volumes

**Scene Wiring Steps**
1. Attach `AudioManager` under `PersistentManagers`.
2. Place `AmbientZoneSystem` triggers in city districts.
3. Assign engine audio clips to `EngineAudioController`.

**Inspector Values**
- `EngineAudioController.minPitch`: `0.8`
- `EngineAudioController.maxPitch`: `2.0`

**Test Procedure**
- Play engine and ambient clips using runtime controls.

---

## PHASE GROUP N — PERFORMANCE

**Scripts**
- `PoolManager`
- `PerformanceManager`
- `AIBudgetManager`

**Folder Placement**
- `Assets/Scripts/Performance/*.cs`

**Prefab Components List**
- `PoolManager` (manager)
- `PerformanceManager` (manager)
- `AIBudgetManager` (manager)

**Scene Wiring Steps**
1. Attach `PoolManager`, `PerformanceManager`, and `AIBudgetManager` under `PersistentManagers`.
2. Register pooled prefabs in `PoolManager`.

**Inspector Values**
- `PerformanceManager.targetFrameRate`: `60`
- `AIBudgetManager.maxActiveAgents`: `50`

**Test Procedure**
- Spawn/despawn pooled objects and confirm reuse.

---

## PHASE GROUP O — TOOLING

**Scripts**
- `CityEditorTool`
- `MissionEditorTool`
- `VehicleEditorTool`

**Folder Placement**
- `Assets/Scripts/Tooling/Editor/*.cs`

**Prefab Components List**
- Editor-only tools are accessed from the Unity menu.

**Scene Wiring Steps**
1. Open `OpenWorldDriving/City Editor` to preview city layout.
2. Open `OpenWorldDriving/Mission Editor` to configure mission graphs.
3. Open `OpenWorldDriving/Vehicle Editor` to adjust stats.

**Inspector Values**
- Editor tool windows expose default parameters for preview generation.

**Test Procedure**
- Open tools via `OpenWorldDriving/` menu and validate editor UI.

---

## Integration Notes
All systems are wired to be modular, event-driven, and expandable. To integrate further, use the `GameEventBus` and `ManagerBase` patterns throughout your gameplay features.

---

## Next Steps
- Implement real procedural generation, AI pathfinding, and networking in each phase.
- Populate prefabs, tune physics, and iterate on content.
