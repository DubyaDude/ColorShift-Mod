# ColorShift
Allows you to approximately see the way colorblind people see. **Would mostly help in game/map/avatar design. Also allows you to make your own custom 'color shifts' which may help those that are colorblind**.

## Project Configuration
Open Command Prompt inside the project folder and type the following (replacing with YOUR directory)

```mklink /j GameIL2CPP "PATH\TO\IL2CPP\GAME"```

```mklink /j GameMono "PATH\TO\MONO\GAME"```

```mklink /j GameMonoData "PATH\TO\MONO\DATA"```

## Keybinds
- **M** - Changing filter mode (Forward)
- **N** - Changing filter mode (Backward)

## Configuration
In MelonPreferences.cfg:
- **MainCamMode**(Enum) - The mode the camera is set to at launch (saved every filter change)
- **Keybinds**(Bool) - To enable/disable the keybinds
- **ShowDifference**(Bool) - Show how much colors have been affected with current filter
- **Custom1-5**(Color[][]) - Cusom color shifts that can be configured by the user

### ColorMatrix presets in Percentages

<table>
   <tbody>
      <tr>
         <td></td>
         <td colspan="3"><strong>Red Channel</strong></td>
         <td colspan="3"><strong>Green Channel</strong></td>
         <td colspan="3"><strong>Blue Channel</strong></td>
      </tr>
      <tr>
         <td><strong>Type</strong></td>
         <td><strong>R</strong></td>
         <td><strong>G</strong></td>
         <td><strong>B</strong></td>
         <td><strong>R</strong></td>
         <td><strong>G</strong></td>
         <td><strong>B</strong></td>
         <td><strong>R</strong></td>
         <td><strong>G</strong></td>
         <td><strong>B</strong></td>
      </tr>
      <tr>
         <td><strong>Normal</strong></td>
         <td>100%</td>
         <td>–</td>
         <td>–</td>
         <td>–</td>
         <td>100%</td>
         <td>–</td>
         <td>–</td>
         <td>–</td>
         <td>100%</td>
      </tr>
      <tr>
         <td><strong>Protanopia</strong></td>
         <td>56.667%</td>
         <td>43.333%</td>
         <td>–</td>
         <td>55.833%</td>
         <td>44.167%</td>
         <td>–</td>
         <td>–</td>
         <td>24.167%</td>
         <td>75.833%</td>
      </tr>
      <tr>
         <td><strong>Protanomaly</strong></td>
         <td>81.667%</td>
         <td>18.333%</td>
         <td>–</td>
         <td>33.333%</td>
         <td>66.667%</td>
         <td>–</td>
         <td>–</td>
         <td>12.5%</td>
         <td>87.5%</td>
      </tr>
      <tr>
         <td><strong>Deuteranopia</strong></td>
         <td>62.5%</td>
         <td>37.5%</td>
         <td>–</td>
         <td>70%</td>
         <td>30%</td>
         <td>–</td>
         <td>–</td>
         <td>30%</td>
         <td>70%</td>
      </tr>
      <tr>
         <td><strong>Deuteranomaly</strong></td>
         <td>80%</td>
         <td>20%</td>
         <td>–</td>
         <td>–</td>
         <td>25.833%</td>
         <td>74.167%</td>
         <td>–</td>
         <td>14.167%</td>
         <td>85.833%</td>
      </tr>
      <tr>
         <td><strong>Tritanopia</strong></td>
         <td>95%</td>
         <td>5%</td>
         <td>–</td>
         <td>–</td>
         <td>43.333%</td>
         <td>56.667%</td>
         <td>–</td>
         <td>47.5%</td>
         <td>52.5%</td>
      </tr>
      <tr>
         <td><strong>Tritanomaly</strong></td>
         <td>96.667%</td>
         <td>3.333%</td>
         <td>–</td>
         <td>–</td>
         <td>73.333%</td>
         <td>26.667%</td>
         <td>–</td>
         <td>18.333%</td>
         <td>81.667%</td>
      </tr>
      <tr>
         <td><strong>Achromatopsia</strong></td>
         <td>29.9%</td>
         <td>58.7%</td>
         <td>11.4%</td>
         <td>29.9%</td>
         <td>58.7%</td>
         <td>11.4%</td>
         <td>29.9%</td>
         <td>58.7%</td>
         <td>11.4%</td>
      </tr>
      <tr>
         <td><strong>Achromatomaly</strong></td>
         <td>61.8%</td>
         <td>32%</td>
         <td>6.2%</td>
         <td>16.3%</td>
         <td>77.5%</td>
         <td>6.2%</td>
         <td>16.3%</td>
         <td>32.0%</td>
         <td>51.6%</td>
      </tr>
   </tbody>
</table>

### ColorMatrix presets in RGB(255)

<table>
   <tbody>
      <tr>
         <td></td>
         <td colspan="3"><strong>Red Channel</strong></td>
         <td colspan="3"><strong>Green Channel</strong></td>
         <td colspan="3"><strong>Blue Channel</strong></td>
      </tr>
      <tr>
         <td><strong>Type</strong></td>
         <td><strong>R</strong></td>
         <td><strong>G</strong></td>
         <td><strong>B</strong></td>
         <td><strong>R</strong></td>
         <td><strong>G</strong></td>
         <td><strong>B</strong></td>
         <td><strong>R</strong></td>
         <td><strong>G</strong></td>
         <td><strong>B</strong></td>
      </tr>
      <tr>
         <td><strong>Normal</strong></td>
         <td>255</td>
         <td>–</td>
         <td>–</td>
         <td>–</td>
         <td>255</td>
         <td>–</td>
         <td>–</td>
         <td>–</td>
         <td>255</td>
      </tr>
      <tr>
         <td><strong>Protanopia</strong></td>
         <td>144.500</td>
         <td>110.499</td>
         <td>–</td>
         <td>142.374</td>
         <td>112.625</td>
         <td>–</td>
         <td>–</td>
         <td>61.625</td>
         <td>193.374</td>
      </tr>
      <tr>
         <td><strong>Protanomaly</strong></td>
         <td>208.250</td>
         <td>110.499</td>
         <td>–</td>
         <td>142.374</td>
         <td>112.625</td>
         <td>–</td>
         <td>–</td>
         <td>61.625</td>
         <td>193.374</td>
      </tr>
      <tr>
         <td><strong>Deuteranopia</strong></td>
         <td>159.375</td>
         <td>95.625</td>
         <td>–</td>
         <td>178.5</td>
         <td>76.5</td>
         <td>–</td>
         <td>–</td>
         <td>76.5</td>
         <td>178.5</td>
      </tr>
      <tr>
         <td><strong>Deuteranomaly</strong></td>
         <td>204.0</td>
         <td>51.0</td>
         <td>–</td>
         <td>–</td>
         <td>65.874</td>
         <td>189.125</td>
         <td>–</td>
         <td>36.125</td>
         <td>218.874</td>
      </tr>
      <tr>
         <td><strong>Tritanopia</strong></td>
         <td>242.25</td>
         <td>12.75</td>
         <td>–</td>
         <td>–</td>
         <td>110.499</td>
         <td>144.500</td>
         <td>–</td>
         <td>121.125</td>
         <td>133.875</td>
      </tr>
      <tr>
         <td><strong>Tritanomaly</strong></td>
         <td>246.500</td>
         <td>8.499</td>
         <td>–</td>
         <td>–</td>
         <td>186.999</td>
         <td>68.000</td>
         <td>–</td>
         <td>46.749</td>
         <td>208.250</td>
      </tr>
      <tr>
         <td><strong>Achromatopsia</strong></td>
         <td>76.244</td>
         <td>149.684</td>
         <td>29.069</td>
         <td>76.244</td>
         <td>149.684</td>
         <td>29.069</td>
         <td>76.244</td>
         <td>149.684</td>
         <td>29.069</td>
      </tr>
      <tr>
         <td><strong>Achromatomaly</strong></td>
         <td>157.589</td>
         <td>81.599</td>
         <td>15.809</td>
         <td>41.565</td>
         <td>197.625</td>
         <td>15.809</td>
         <td>41.565</td>
         <td>81.599</td>
         <td>131.579</td>
      </tr>
   </tbody>
</table>

## Sources:
- [ColorMatrix Pattern](https://web.archive.org/web/20091001043530/http://www.colorjack.com/labs/colormatrix/)
- [Color-blind type facts](https://www.color-blindness.com/types-of-color-blindness/)

## Credits:
- [Requi](https://github.com/RequiDev) - For helping me figure out the funky shader stuff when it came to VR.
- Venclaire - For pushing me to make the mod in the first place.

## DISCLAIMERS:
- \*This mod in no way is meant to act as a 'ColorBlind mode' for games. This mod is supposed to emulate an approximation of what colorblind people may see to account for color-blind people during game/map/avatar development. 
  - HOWEVER some people that I've spoken to who were colorblind said that this helped in general gameplay, unfortunately, this is NOT what should be done to account for color-blind people. However, if it does indeed make others' experience better, then be free to use it as such.
- \*\*The accuracy of the preset color matrix is known to be inaccurate as the original author of these values himself stated "the ColorMatrix version is very simplified, and not accurate" ([Source](https://web.archive.org/web/20141226095637/http://kaioa.com/node/75#comment-247))
