Um den Microservice Wetter auszuführen werden 2 Docker-Container benötigt: MicroserviceAPIWetter (der eigentliche Microservice) und WetterDatenbank (PostgreSQL Datenbank).
Die Datenbank befindet sich in einem eigenen Container, um sie austauschbar zu machen. Dazu muss nur das Config-File angepasst werden.
