Um den Microservice Wetter auszuführen werden 2 Docker-Container benötigt: MicroserviceAPIWetter (der eigentliche Microservice) und WetterDatenbank (PostgreSQL Datenbank).
Die Datenbank befindet sich in einem eigenen Container, um sie austauschbar zu machen. Dazu muss nur das Config-File angepasst werden. <br>
Docker Image: docker pull ghcr.io/swesaskiah98/microservicewetter:master <br>
Die Applikation ist plattform unabhängig und wird auch für verschiedene Plattformen auf Github getestet (Linux, Windows, MacOS). <br>
Falls die Exception "Npgsql.NpgsqlException: Failed to connect to 172.17.0.2:5432" beim Start erscheint, muss in App.Config der Host angepasst werden. Die IP-Adresse kann mittels "docker inspect WetterDatenbank" abgerufen werden und dann als Host in App.config eingetragen werden.
