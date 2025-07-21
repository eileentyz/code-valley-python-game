# Living Room Scene Setup Guide 🏠

This guide will help you create a simple living room scene with a laptop, bed, door, and UI buttons for settings and store.

## 📋 Prerequisites

- Unity 2022.3 LTS or later
- TextMeshPro package installed
- All scripts from the Code Valley project

## 🎯 Scene Structure

```
LivingRoomScene
├── Player
├── Laptop (on Desk)
├── Bed
├── Door
├── UI Canvas
│   ├── Main Menu Panel
│   ├── Settings Panel
│   └── Store Panel
├── Camera
└── Audio Sources
```

## 🚀 Step-by-Step Setup

### 1. Create the Scene

1. **Create New Scene**
   - File → New Scene
   - Save as "LivingRoomScene"

2. **Set up Camera**
   - Select Main Camera
   - Set Projection to "Orthographic"
   - Set Size to 5
   - Position at (0, 0, -10)

### 2. Create Basic Objects

#### **Player**
```
- Create Empty GameObject → Name: "Player"
- Add SpriteRenderer component
- Add Rigidbody2D (set Gravity Scale to 0)
- Add BoxCollider2D
- Add PlayerController script
- Position at (0, 0, 0)
```

#### **Laptop & Desk**
```
- Create Empty GameObject → Name: "Desk"
- Add SpriteRenderer component
- Position at (2, 0, 0)
- Create Empty GameObject → Name: "Laptop"
- Add SpriteRenderer component
- Add LaptopInteractable script
- Add BoxCollider2D (set as trigger)
- Add AudioSource
- Position on top of desk
```

#### **Bed**
```
- Create Empty GameObject → Name: "Bed"
- Add SpriteRenderer component
- Add BedInteractable script
- Add BoxCollider2D (set as trigger)
- Add AudioSource
- Position at (-2, 0, 0)
```

#### **Door**
```
- Create Empty GameObject → Name: "Door"
- Add SpriteRenderer component
- Add DoorInteractable script
- Add BoxCollider2D (set as trigger)
- Add AudioSource
- Position at (0, 2, 0)
```

### 3. Set up UI Canvas

#### **Main Canvas**
```
- Create UI → Canvas
- Set Render Mode to "Screen Space - Overlay"
- Add CanvasScaler component
- Set UI Scale Mode to "Scale With Screen Size"
```

#### **Main Menu Panel**
```
- Create Empty GameObject → Name: "MainMenuPanel"
- Add Image component (for background)
- Add MainMenuUI script
- Create child buttons:
  - Settings Button
  - Store Button
  - Start Game Button
  - Quit Button
```

#### **Settings Panel**
```
- Create Empty GameObject → Name: "SettingsPanel"
- Add Image component
- Add child elements:
  - Music Volume Slider
  - SFX Volume Slider
  - Fullscreen Toggle
  - Save Settings Button
  - Back Button
```

#### **Store Panel**
```
- Create Empty GameObject → Name: "StorePanel"
- Add Image component
- Add ScrollView for store items
- Add child elements:
  - Store Content (for items)
  - Player Coins Text
  - Back Button
```

### 4. Add Required Scripts

#### **Scene Manager**
```
- Create Empty GameObject → Name: "SceneManager"
- Add LivingRoomScene script
- Assign all references in inspector
```

#### **Game Systems**
```
- Create Empty GameObject → Name: "GameManager"
- Add GameManager script

- Create Empty GameObject → Name: "SaveSystem"
- Add SaveSystem script

- Create Empty GameObject → Name: "AreaManager"
- Add AreaManager script

- Create Empty GameObject → Name: "DecorationSystem"
- Add DecorationSystem script
```

### 5. Set up Audio

#### **Audio Sources**
```
- Create Empty GameObject → Name: "MusicAudioSource"
- Add AudioSource component
- Set Loop to true
- Set Volume to 0.7

- Create Empty GameObject → Name: "SFXAudioSource"
- Add AudioSource component
- Set Volume to 0.8
```

### 6. Configure Components

#### **PlayerController Setup**
```
- Set Move Speed to 5
- Set Sprint Speed to 8
- Set Interaction Range to 2
- Assign Interactable Layer Mask
```

#### **LaptopInteractable Setup**
```
- Assign Coding Interface (UI panel)
- Assign Interaction Indicator
- Assign Audio Source
```

#### **DoorInteractable Setup**
```
- Set Target Area ID to "Garden"
- Assign Interaction Indicator
- Assign Audio Source
```

#### **BedInteractable Setup**
```
- Assign Sleep Interface (UI panel)
- Assign Interaction Indicator
- Assign Audio Source
```

### 7. Create Simple Sprites

#### **Player Sprite**
```
- Create 32x32 texture
- Fill with blue color
- Create Sprite
- Assign to Player's SpriteRenderer
```

#### **Laptop Sprite**
```
- Create 64x48 texture
- Fill with dark gray color
- Add white rectangle for screen
- Create Sprite
- Assign to Laptop's SpriteRenderer
```

#### **Bed Sprite**
```
- Create 96x64 texture
- Fill with brown color
- Add white rectangle for sheets
- Create Sprite
- Assign to Bed's SpriteRenderer
```

#### **Door Sprite**
```
- Create 32x64 texture
- Fill with brown color
- Add darker rectangle for door frame
- Create Sprite
- Assign to Door's SpriteRenderer
```

### 8. Set up Layers

#### **Layer Configuration**
```
- Create "Interactable" layer
- Assign to Laptop, Bed, and Door
- Set PlayerController's Interactable Layer Mask
```

### 9. Test the Scene

#### **Basic Functionality Test**
1. **Player Movement**: WASD keys should move the player
2. **Interaction**: E key should interact with objects
3. **UI Navigation**: Settings and Store buttons should work
4. **Audio**: Audio sources should be configured

## 🎨 UI Layout Example

### **Main Menu Layout**
```
┌─────────────────────────┐
│     Code Valley         │
│                         │
│   [Start Game]          │
│   [Settings]            │
│   [Store]               │
│   [Quit]                │
└─────────────────────────┘
```

### **Settings Layout**
```
┌─────────────────────────┐
│       Settings          │
│                         │
│ Music Volume: [██████]  │
│ SFX Volume:   [██████]  │
│ Fullscreen:   [✓]       │
│                         │
│   [Save] [Back]         │
└─────────────────────────┘
```

### **Store Layout**
```
┌─────────────────────────┐
│        Store            │
│ Coins: 100              │
│                         │
│ Basic Desk - 50 coins   │
│ [Buy]                   │
│                         │
│ Chair - 75 coins        │
│ [Buy]                   │
│                         │
│   [Back]                │
└─────────────────────────┘
```

## 🔧 Troubleshooting

### **Common Issues**

1. **Player not moving**
   - Check Rigidbody2D settings
   - Ensure PlayerController script is attached
   - Verify input axes are configured

2. **Interaction not working**
   - Check Interactable layer assignment
   - Verify colliders are set as triggers
   - Ensure IInteractable scripts are attached

3. **UI not responding**
   - Check button event listeners
   - Verify MainMenuUI script references
   - Ensure Canvas is properly configured

4. **Audio not playing**
   - Check AudioSource components
   - Verify audio clips are assigned
   - Check volume settings

## 🎯 Next Steps

After setting up the basic scene:

1. **Add Visual Assets**: Replace placeholder sprites with proper artwork
2. **Add Audio**: Include background music and sound effects
3. **Polish UI**: Improve visual design and animations
4. **Add More Features**: Expand the game with additional areas and content

## 📝 Notes

- All scripts are designed to work together automatically
- The LivingRoomScene script handles most setup automatically
- You can customize positions and sizes in the inspector
- The scene is ready for immediate testing and development

---

**Happy Coding! 🐍✨** 