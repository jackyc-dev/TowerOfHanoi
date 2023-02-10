# TowerOfHanoi

Initial work on a Tower Of Hanoi game using unity

Tasks:
- Core
  - Implement Drag & Drop [Done]
  - Wire events for Drop collision [Done]
- Component as Template Setup (will move to prefab) [Done]
  - Disk with parameters that allows for customizability [Done]
  - Tower component
    - Tracking of Disks from component instead of a game tracker [Done]
    - Fix tracking on disks as they are being moved between Towers [Done]
- UI Components - Wire into events
  - Reset Button [Done]
  - Disk Count Drop Down [Done]
  - Win label [Done]
- Game Mechanics
  - Invalidate drop event and revert Disk location back to its source [Done]
  - Explore if we can allow updating the number of Disks in the game
  - Tracking on Tower's disk content
    - establish win condition [Done]
 - For Refactoring
  - Establish practice where we interact w/ other objects through its interfaces and contracts [Done]