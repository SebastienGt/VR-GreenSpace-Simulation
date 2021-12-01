---
title: Virtual Reality Greenhouse
author: Sébastien Friedberg and Kevin Michael Frick
date: November 2021
---

# Introduction

This application is a virtual reality environment which simulates a greenhouse in space, developed for the Virtual and Augmented Reality course held for the Master in Innovation and Research in Informatics by Prof. Pelechano, Prof. Andujar and Prof. Fairen at Universitat Politècnica de Catalunya in the academic year 2021/2022.

The application was developed using Unity 2021.2 and Google Cardboard.

# Selection and manipulation

The game is entirely based on gaze input for selection, manipulation and navigation.
Interactable objects are selected by looking at them for three seconds.
If the player is too far, a red cursor will be displayed.

The player can move around the rooms by looking at the teleportation markers on the ground.

The seed distributors allow the player to take a seed and translate it to the spots in the main room, in order to grow a plant.
Once a plant is fully grown, it can be sold for money.

# Environment

There are two rooms, a starting room with a main menu and a main room where the greenhouse is actually located.
The player can move back and forth between the starting and main room via appropriate menu items. 

# Navigation

Two navigation metaphors are implemented, instant teleport and smooth movement. 
If instant teleport is chosen, selecting a teleportation marker will instantly teleport the player there.
Smooth movement, on the other hand, moves the player towards the selected teleportation marker with smooth acceleration and deceleration, using linear interpolation on the player's position.

# Control

Besides starting the game, the main menu allows the player to switch between navigation methods by selecting the relevant option.

When the player is in the main room, controls are available for the player to change the growth rate of their plants.
A faster growth rate costs money.

# Objectives and UI

The objective of the game is to make the most money possible, by buying seeds and selling grown plants.
The amount of money available is shown on a heads-up display.


