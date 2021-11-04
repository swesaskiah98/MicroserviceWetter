1. Codebase: Als Revision Control wurde GitHub verwendet. Es gibt nur eine Codebase für die Applikation.
2. Dependencies: die Dependencies zu den NuGet Packages werden explicit deklariert.
3. Config: In der Config werden die Zugänge zu der Postgres-Datenbank angegeben. Die Postgres-Datenbank läuft in einem getrennten Docker-Container, welcher leicht ausgetauscht werden kann, indem die Config geändert wird.
4. Backing Service: als Backing-Service wird eine Postgres Datenbank verwendet.
5. Build release run: die Applikation wird mittels Workflow auf GitHub released. Der Workflow wird täglich gestartet, sowie wenn auf Master gepushed wird.
6. Process: es wird angenommen, dass die Applikation stateless ist, daher werden die Daten immer direkt aus der Datenbank geladen und niemals aus dem Cache der Applikation.
7. Port binding: die Applikation läuft in einem Docker-Container, aller Verbindungen laufen über einen Port.
10. Dev/Prod Parity: die Applikation wird mittels GitHub Workflow kontinuierlich deployed und getestet, um Development und Production möglichst ähnlich zu halten. 
