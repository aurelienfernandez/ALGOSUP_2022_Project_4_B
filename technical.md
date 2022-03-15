# Technical Specification

## 2022 project 4 virtual B3

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
  
<!-- - [1. Front matter](#1-front-matter) -->
- [1. Introduction](#1-introduction)
  - [a. Overview](#a-overview)
  - [b. Glossary](#b-glossary)
  - [c. Product and Technical Requirements](#c-product-and-technical-requirements)
  - [d. Out of scope](#d-out-of-scope)
- [2. Solution](#2-solution)
  - [a. Existing solution](#a-existing-solution)
  - [b. Design](#b-design)
- [3. Additional consideration](#3-Additional-consideration)
  - [a. Risks](#a-risks)
  - [b. Privacy Consideration](#b-privacy-consideration)
- [4. Work](#4-work)
  - [a. Work estimations and timelines](#a-work-estimations-and-timelines)
  - [b. Priorities](#b-priorities)
  - [c. Milestones](#c-milestones)

</details>

---

## 1. Introduction

### a. Overview

Plan all the issues could be happened in a school it's not an easy things to do. So the goal of this project is to recreate a simulation in VR of the school to find all the future problems and fix them before the launch of the building. Some examples of problem:

- The number of toilets,
- The time it takes for a student to go from one room to another,
- The number of microwave in the relax room,
- The number of people that could possibly gather in each rooms.

 The entire of this project must be done in **Unity 2020.3.29f1**. We have decided to use this version and not the latest to avoid potential problem with a new version. In Unity all scripts are written in C# and for that we use Visual Studio Community 2019 with all extensions to develop a VR simulation. The headset we use is an Oculus Quest 2. This headset is independant so we can use it without cable and without spend too much time with headset's configurations.  

### b. Glossary

|terms|definitions|
|-|-|
|VR|Virtual reality|
|B3|Algosup's next building, it means building number 3|

### c. Product and Technical Requirements

| Technical | Using |
|-|-|
|[C#](https://docs.microsoft.com/fr-fr/dotnet/csharp/)| We code in C# because it's the language used by default in Unity |
|[Unity](https://store.unity.com/fr#plans-individual)| Unity is a cross-platform game engine. The engine has since been gradually extended to support a variety of desktop, mobile, console and virtual reality platforms.
|[Visual Studio Community 2019](https://visualstudio.microsoft.com/fr/downloads/)|We use VSCommunity for this project because it's less complicated to work on it in C#.   |
|[Asset store Unity](https://assetstore.unity.com/) |The Unity Asset Store is an ever-expanding library of resources. Unity Technologies and community members create these resources and publish them from the Asset Store. |
|[.NET 6.O](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)| We use this version of .NET because it is the latest and the more efficient version|

### d. Out of scope



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
|Time|We might not finish every tasks within the seven weeks|
|Size|If the simulation is too big it might affect performances|

### b. Privacy consideration

The simulation doesn't need any user data to be downloaded nor to be played so user's don't have to worry about private information or possible data leaks.

## 4. Work

### a. Work estimations and timelines

### b. Priorities

Our priorities are :

- Create NPCs who navigates trough the school
- Create various interaction with the environment

### c. Milestones

- Friday 4<sup>th</sup> March 2022 we have to presents our documentation, functionnal and technical specification.

- between the 7<sup>th</sup> and the 11<sup>th</sup> March 2022 we will have to present our deliverables to our client.

- Friday 8<sup>th</sup> April we have to present and demonstrate the result of our project to our client.
