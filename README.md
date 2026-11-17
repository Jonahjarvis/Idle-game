# Fantasy Idle RPG

A progression-fantasy idle RPG built in **Godot 4** using **C#**, inspired by *Cradle*. The player can cycle idle mana cultivation and physical training tasks to build core stats, unlock progression milestones, and multiply combat class experience across a skill tree which will eventually allow unique builds.

---

## Key Features

* **Autonomous Progression & Idle Loops:** Pausable mana cycling, core expansion and mana flow concentration tasks to increase stats.
* **Hybrid Training & Combat Loop:** Timed idle training tasks (so far just mana and mana regen) progressively increase stats to advance.
* **Dynamic UI Generation:** Automatically populates and categorizes task buttons into **Training** and **Combat** columns at runtime based on task logic, paired with custom `TextureProgressBar` indicators.

---

## Architecture & Design Patterns

The codebase follows a decoupled **Model-View-Controller (MVC)** pattern to separate simulation logic from Godot's UI scene tree:

* **State & Simulation (`GameManager` & `PlayerStats`):** `GameManager` serves as the central backend controller, enforcing a single-active-task constraint for processing using `_Process(double delta)`.
* **Polymorphic Task System (`GameTask`):** Built around an abstract `GameTask` base class (`[GlobalClass]`) with specialized subclasses (`TimerTask`, `ToggleTask`) and `TaskCategory` enums, allowing new tasks to be added without modifying manager or UI code.
* **Decoupled Presentation (`UIManager`):** Listens to backend state changes and dynamically binds task actions via C# lambda callbacks, keeping UI nodes independent of core game rules.
