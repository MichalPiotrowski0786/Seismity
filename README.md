# Seismity
3D Visualizer of recent Earthquakes



Technologies used:

| Technology | Link |
| :---: | :---: |
| IDE: VS Code | https://code.visualstudio.com |
| Language: C# | https://docs.microsoft.com/pl-pl/dotnet/csharp |
| Version Control: Git & Github | https://github.com |
| Unity Engine | https://unity.com/ |
| Web Request | https://docs.microsoft.com/pl-pl/dotnet/api/system.net.webrequest?view=net-5.0 |
| USGS Earthquake CSV feed | https://earthquake.usgs.gov/earthquakes/feed/v1.0/csv.php |



Unity Components used:

|  |  |  |  | 
| :---: | :---: | :---: | :---: |
| Transform | Camera | Box Collider | Rigidbody | 
| Post Process Volume | Camera Controller | Light | Mesh Filter |
| Mesh Renderer | Sphere Collider | Earthquakes Controller | Rect Transform |
| Canvas | Canvas Scaler | Graphic Raycaster | UI Controller |
| Canvas Renderer | Image | Dropdown | Text |
| Scroll Rect | Button | Event System | Standalone Input Module |
| Material | Shader | .cs | .csv |



Functional requirements:

| Id | Category | Name | Description | Required?(Y/N) |
| :---: | :---: | :---: | :---: | :---: |
| WF0 | Function | 3D Visualization | Displaying Earth seismic activity in 3D space placed onto Earth 3D Model | Y |
| WF1 | Function | Downloading data | Downloading data from USGS CSV feed with one-minute interval | Y |
| WF3 | Function | Camera Controller | Camera Controller responsible for moving user view. Includes: translations, rotations and zoom | Y |
| WF2 | Graphics | UI | Responsible for displaying additional informations, buttons and lists  | Y |
| WF2 | Testing | Unit Tests | Made to check correct operating of our code and functions | Y |
| WF4 | Graphics | Post-Processsing | Handles graphical enhacements to visualizator like: Bloom, Sharpen, Motion Blur, Vignette etc. | N |



Non-Functional requirements:

| Id | Name | Description | Required?(Y/N) |
| :---: | :---: | :---: | :---: |
| WNF0 | Reliability | Frequent code reviews, fixing errors and making tests | Y |
| WNF1 | Effectivness | Optimizing App, to use less resources and lower load on CPU and RAM | Y |
| WNF3 | Compatibility | Checing if app is capable on working with most of desktop devices. Mobile devices in future | Y |
| WNF2 | Honesty | Being honest with our progress, problems and solutions | Y |
| WNF4 | Usability | Making sure that our actions make sense and things that we add are needed | Y |



Bugs:

| Bug | Description | Fixed? | Possible fix |
| :---: | :---: | :---: | :---: |
| Incorrect positions | Earthquakes positions are offset from their local locations with no evident pattern | [X] | Try new math methods or replace current Earth 3D Model with better one |



Copyright laws:

| Authors | Licension | Link |
| :---: | :---: | :---: |
| Oskar Cyms, Paweł Rogoża, Michał Piotrowski | Creative Commons(CC BY-NC-ND) | https://creativecommons.org/licenses/by-nc-nd/4.0/legalcode |



Screenshots:
<p align="center">
  <kbd>
    <img src="/Assets/Screenshots/0.png?raw=true">
  </kbd>
</p>
<p align="center">
  <kbd>
    <img src="/Assets/Screenshots/1.png?raw=true">
  </kbd>
</p>
<p align="center">
  <kbd>
    <img src="/Assets/Screenshots/3.jpeg?raw=true">
  </kbd>
</p>
<p align="center">
  <kbd>
    <img src="/Assets/Screenshots/4.png?raw=true">
  </kbd>
</p>
<p align="center">
  <kbd>
    <img src="/Assets/Screenshots/2.png?raw=true">
  </kbd>
</p>
