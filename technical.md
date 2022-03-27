# Technical Specification

## 2022 project 4 virtual B3 Group B

The project began February 21<sup>th</sup> 2022 and will end April 8<sup>th</sup> 2022.

This Project is create by a team composed of :

- [Remy Charles](https://github.com/RemyCHARLES)
- [Robin Debry](https://github.com/robin-debry)
- [Paul Nowak](https://github.com/PaulNowak36)
- [Aurélien Fernandez](https://github.com/aurelienfernandez)
- [Laura-lee Hollande](https://github.com/lauraleehollande)
- [Thomas Planchard](https://github.com/thomas-planchard)

---

<details><summary>Table of Contents</summary>
  
- [Technical Specification](#technical-specification)
  - [2022 project 4 virtual B3 Group B](#2022-project-4-virtual-b3-group-b)
  - [1. Introduction](#1-introduction)
    - [a. Overview](#a-overview)
    - [b. Glossary](#b-glossary)
    - [c. Product and Technical Requirements](#c-product-and-technical-requirements)
    - [d. Configuration](#d-configuration)
    - [e. Out of scope](#e-out-of-scope)
  - [2. Solution](#2-solution)
    - [a.Existing solution](#aexisting-solution)
  - [b. Design](#b-design)
  - [3. Additional consideration](#3-additional-consideration)
    - [a. Risks](#a-risks)
    - [b. Privacy consideration](#b-privacy-consideration)
  - [4. Work](#4-work)
    - [a. Work estimations and timelines](#a-work-estimations-and-timelines)
    - [b. Priorities](#b-priorities)
    - [c. Milestones](#c-milestones)
    - [d. Technical risks](#d-technical-risks)
  - [List of asset :](#list-of-asset-)

</details>

---

## 1. Introduction

### a. Overview

Plan all the issues could be happened in a school it's not an easy things to do. So the goal of this project is to recreate a simulation in VR of the school to find all the future problems and fix them before the launch of the building. Some examples of problem:

- The number of toilets,
- The time it takes for a student to go from one room to another,
- The number of microwave in the relax room,
- The number of people that could possibly gather in each rooms.

 The entire of this project must be done in **Unity 2021.2.16f1**. We have decided to use this version and not the latest to avoid potential problem with a new version. In Unity all scripts are written in C# and for that we use Visual Studio Community 2019 with all extensions to develop a VR simulation. The headset we use is an Oculus Quest 2. This headset is independant so we can use it without cable and without spend too much time with headset's configurations.  

### b. Glossary

|terms|definitions|
|-|-|
|VR|Virtual reality|
|B3|The B3 was originally a tractor factory, which was closed in 1994 and is partly listed as a historical monument. The B3 is the next building for the ALGOSUP school, which will occupy the ground floor. In addition, the first floor will be occupied by the CNAM.|

### c. Product and Technical Requirements

| Technical | Using |
|-|-|
|[C#](https://docs.microsoft.com/fr-fr/dotnet/csharp/)| We code in C# because it's the language used by default in Unity. |
|[Unity](https://store.unity.com/fr#plans-individual)| Unity is a cross-platform game engine. The engine has since been gradually extended to support a variety of desktop, mobile, console and virtual reality platforms.
|[Visual Studio Community 2019](https://visualstudio.microsoft.com/fr/downloads/)|We use VSCommunity for this project because it's less complicated to work on it in C#.   |
|[Asset store Unity](https://assetstore.unity.com/) |The Unity Asset Store is an ever-expanding library of resources. Unity Technologies and community members create these resources and publish them from the Asset Store. |
|[.NET 6.O](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)| We use this version of .NET because it is the latest and the more efficient version.|
|[ambientCG](https://ambientcg.com/)|We use this Website to have all of texture we want. |
### d. Configuration

Like our laptops don't have graphic cards we need to build this unity project with a specific way so there are the steps to follow :
  - Create a new Unity project using version 2020.
    You can use the 3D template (default).
---
  - Switch the target platform to Android
    Because we’re targeting Quest 2 which is running on Android, we need to switch the project to Android. In case you are targeting a PC VR headset (HTC Vive, Valve Index, …), you need to target PC.
    Go to File->Build Settings (or Unity->Build Settings on Mac), select Android and click Switch Platform.
---
  - Edit the settings
  
    These settings are required to build on Quest (can be different for other headsets).

  While the Build Settings window is still open, set the Texture Compression to ASTC.
  
  Then, go to Edit->Project Settings and select the Player tab.
  Make sure the Android tab is selected and set the following settings:

  Under Other Settings:
  - Set Color Space to Linear.
  - Remove Vulkan from Graphics API list.
  - Set Minimum API Level to Android 6.0 Marshmallow (API level 23).
  - Make sure Target API Level is set to Automatic (highest installed).

---
  - Enable VR in the project
    In the Project Settings window (Edit->Project Settings), select the XR Plugin Management tab and click on Install XR Plugin Management.

    To make our project run in Quest, under the Android tab, check the Oculus box in Plug-ins Providers.
---
  - Install XR Interaction Toolkit
    Go to Window->Package Manager, in the Packages, select Unity Registry and look for XR Interaction Toolkit in the list. Select it and click Install.

    You might have windows asking you if you want to use the new Input System and asking confirmation to use the Interaction Layer. Choose ‘Yes’ and ‘I Made A Backup, Go Ahead!’ Your Unity project will restart.
    When the Unity Editor is back, still in the Package Manager window with XR Interaction Toolkit selected, expand Samples and click the Import button next to Starter Assets.
---
  - Set up inputs
    The XR Interaction Toolkit is using the new input system and provides sample VR inputs ready to use.
    In the Project window, go to Assets/Samples/XR Interaction Toolkit/2.0.1/Starter Assets, select XRI Default Left Controller.preset and click on ‘Add to ActionBasedController default’ in the Inspector window:

    Do the same for XRI Default Right Controller.preset and XRI Default Snap Turn.preset.
    Then, go to Project Settings (Edit->Project Settings) and select the Preset Manager tab. In the ActionBasedController section, set respectively ‘Left’ and ‘Right’ in the Filter field for left and right controller presets:
---
  - Make a simple scene
  
    Create a new scene or use an existing one. Add an XR Rig (Action-Based), a Teleportation Area and a Grab Interactable

    On the newly created XR Origin GameObject, look for the XR Origin component and set the Tracking Origin to Floor.
    Add an InputActionManager component to that GameObject and add the XRIDefaultInputActions file to the Action Assets list:

    Add spheres (or any other 3D models representing hands/controllers) as a child of both LeftHand Controller and RightHand Controller under XR Origin/Camera Offset.

---
  - Build and run your app
  
    Your scene is now ready to be sent to the headset.
    Connect your Quest to the PC/Mac using ADB (details on how to install it here(Windows) and here(Mac)).
    Open the Build Settings window (File->Build Settings or Unity->Build Settings).<br> Add your scene to the Scenes In Build list (drag and drop from Project window or ‘Add Open Scenes’ while your scene is opened).
    Your device should appear in the Run Device list field*.<br> Select it, press Build And Run and choose where you want the APK file to be saved. After waiting a few, your app will be built and directly played in the headset, enjoy!<br>
    If not, make sure your headset is on, check its connection with the PC/Mac and check the ADB setup. Then click Refresh.

### e. Out of scope

## 2. Solution

### a.Existing solution

This is an example of what we want. We want an experience as close as possible as you an see on the video just below.

---
[![miniature](img/miniature)](https://www.youtube.com/watch?v=eTt7AGIpV2I&t=67s)
<p style= "font-size:10pt">you can click on the picture to watch the video.</p>

---

## b. Design

 Below you have a screenshot of the 3D plan open with Unity. As you can see all the structure don't have texture. So we are free to design it as we want.

![B3](img/B3Image)

## 3. Additional consideration

### a. Risks

|Risk|Impact|
|-|-|
|Time|We might not finish every tasks within the seven weeks.|
|Size|If the simulation is too big it might affect performances.|

### b. Privacy consideration

The simulation doesn't need any user data to be downloaded nor to be played so user's don't have to worry about private information or possible data leaks.

## 4. Work

### a. Work estimations and timelines

### b. Priorities

Our priorities are :

- Convert the actual file of the B3 because it's to heavy to push it on github without problem.
- Create NPCs who navigates trough the school.
- Create various interaction with the environment.

### c. Milestones

- Friday 4<sup>th</sup> March 2022 we have to presents our documentation, functionnal and technical specification.

- between the 7<sup>th</sup> and the 11<sup>th</sup> March 2022 we will have to present our deliverables to our client.

- Friday 8<sup>th</sup> April we have to present and demonstrate the result of our project to our client.

### d. Technical risks
One of the biggest risk during this project is its weight. If the project is to heavy, it would cause problems of fluidity. The immersive experience could be impact and annoying the user or even cause motion sickness.

**Problems encountered:**
- The base fbx file was over 100MB so we had to use Git LFS the problem we hadn't foreseen is that Git LFS has a storage and bandwidth limit so when we added items to the B3 over the weeks we So when we added items to the B3 over the weeks we reached the storage and bandwidth limit so we couldn't pull any more and therefore we couldn't push any more and so we had to make sure that the B3 was less than 100MB so that we didn't have the problems of Git LFS.

- Computers do not provide enough power for smooth export and launch of fbx files which takes a long time at each launch or export.



## List of asset :
- [Ashtray](https://www.cgtrader.com/free-3d-models/interior/interior-office/used-ashtray)
- [Microwave](https://www.cgtrader.com/free-3d-models/interior/kitchen/microwave-19523085-bd6e-4046-a0d2-39f7bb44c0bb)
- [Pool table](https://free3d.com/3d-model/pool-table-v1--600461.html)
- [Sofa](https://www.cgtrader.com/free-3d-models/interior/house-interior/mirabel-pewter-sofa)
- [Pouf](https://www.cgtrader.com/free-3d-models/furniture/other/fabric-pouf)
- [Glass](https://www.cgtrader.com/free-3d-models/household/other/wine-glasses--3)
- [Aloe vera plant](https://www.cgtrader.com/free-3d-models/plant/pot-plant/aloe-vera-plant-dcc07e32-ba23-4674-af4c-a52d6f608b91)
- [tall plant pot](https://www.cgtrader.com/free-3d-models/plant/pot-plant/tall-plant-pot)
- [Coffe machine](https://www.cgtrader.com/free-3d-models/household/kitchenware/coffee-machine-rigged)
- [Office drink machine](https://www.cgtrader.com/free-3d-models/interior/interior-office/office-drink-machines-low-poly)
- [Coffee cup](https://www.cgtrader.com/free-3d-models/household/kitchenware/cafe-coffee-cup-3d-model)
- [Weelchair](https://www.cgtrader.com/free-3d-models/science/medical/wheelchair-16868cf7-6f77-452e-b2c3-2cd9c73ae06a)
- [Drone](https://free3d.com/3d-model/drone-costume-411845.html)
- [Extension cable](https://www.cgtrader.com/free-3d-models/electronics/other/extension-cable)
- [Access Machine](:https://www.cgtrader.com/free-3d-models/electronics/other/sci-fi-access-machine)
- [Kitchen sponge](https://www.cgtrader.com/free-3d-models/household/kitchenware/free-kitchen-sponge)
- [Wall plug](https://www.turbosquid.com/fr/3d-models/wall-plug-3d-model/421718#)
- [Paving stone](https://ambientcg.com/view?id=PavingStones035)
- [Fire extinguisher](https://www.cgtrader.com/free-3d-models/architectural/other/fire-extinguisher-low-poly)
- [Clock](https://www.cgtrader.com/free-3d-models/interior/interior-office/clock-bge-cycles-or-with-constraints-for-animations)
- [Books](https://assetstore.unity.com/packages/3d/props/interior/qa-books-115415)
- [Office props](https://assetstore.unity.com/packages/3d/environments/low-poly-office-props-lite-131438)
- [School supplies](https://assetstore.unity.com/packages/3d/school-supplies-96667)
- [Toilet paper roll](https://assetstore.unity.com/packages/3d/props/toilet-paper-roll-proto-series-165615)
- [Printer](https://assetstore.unity.com/packages/3d/props/electronics/printer-lowpoly-4996)
- [Kitchen Appliance](https://assetstore.unity.com/packages/3d/props/electronics/kitchen-appliance-low-poly-180419)
<!-- - []()
- []()
- []()
- []()
- []()
- []()
- []()
- []()
- []() -->