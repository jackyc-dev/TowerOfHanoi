# TowerOfHanoi

Initial work on a Tower Of Hanoi game using unity

Tasks:
- Core
  - Implement Drag & Drop [Done]
  - Wire events for Drop collision [Done]
- Component as Template Setup (will move to prefab)
  - Disk with parameters that allows for customizability [Done]
  - Tower component
    - Tracking of Disks from component instead of a game tracker
- Game Mechanics
  - Invalidate drop event and revert Disk location back to its source
  - Explore if we can allow updating the number of Disks in the game
  - Tracking on Tower's disk content
    - establish win condition
