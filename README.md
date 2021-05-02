# Seismity
3D Visualizer of recent Earthquakes

Technologies used:
  - Unity Engine
  - Web Request for accessing data
  - USGS Earthquake CSV feed 

Functions:
  - 3D Visualization of Earthquakes with their location and intensity
  - Free camera movement and zoom
  - Immersive background
  - 1 minute interval data updates from USGS site
  - List to choose earthquakes that we are intrested in
  - Post processing(Vignette, HDR, Bloom, Motion Blur, Color correction)
  - (Optional) Day/Night cylce
  - (Optional) Display advanced info about chosen earthquake

Bugs:
  - Camera position after inspecting earthquake and moving with mouse is resetting own position to initial location
  - Earthquakes does not update every time after launching visualization
  - Earthquakes positions are offset from their expected location(Parsing issue(?) or bad math implementation(?))

Screenshots:
!["0"](/Assets/Screenshots/0.png?raw=true)
!["1"](/Assets/Screenshots/1.png?raw=true)
