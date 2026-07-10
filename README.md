# Incremental_Game
Unity incremental game project with the focus on event driven architecture.

In this project I decided to focus on Event Driven Architecture, specifically making a small incremental game where systems work with events rather than direct references, like through the inspector.

The biggest issue I faced was not implementing ScriptableObjects in the project, which is something I will look into as a good source of holding data, making it easier to manipulate and such.

The main system, which is a click button, value controller, text update, achievement system, upgrade system & upgrade logic, are all decoupled from each other. Removing one leaves the rest in a working state, even with logic gone to create more achievements or upgrades, the upgrades themselves still work, for example.
The text updater was a simple; but very clean win, being way superior over the regular update method, only being called when the value actually changes, removing any overhead.

The main challenge was building dynamic achievements and upgrades in a way that was both data-driven and event-responsive. Preventing duplicate achievements required some iteration, ultimately solved with a HashSet. Upgrades needed their data in a class rather than a struct so that runtime state like cost scaling and purchase count could be mutated on a shared instance.

However, the value controller did end up as a glorified singleton, which was the main part I couldn't find a solution that did not fit a clean event driven architecture. A proper event bus would've made this a fully disconnected system, but that would be over-kill for such a small project as this.