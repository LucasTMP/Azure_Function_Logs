[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
![Contribuidores](https://badgen.net/badge/Contribuidores/6?icon=github)

<hr>

![Badge](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Badge](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![Badge](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white)
![Badge](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)
![Badge](https://img.shields.io/badge/xUnity-100000?style=for-the-badge&logo=unity&logoColor=white)
![Badge](https://img.shields.io/badge/GitHub_Actions-2088FF?style=for-the-badge&logo=github-actions&logoColor=white)
![Badge](https://img.shields.io/badge/Insomnia-5849be?style=for-the-badge&logo=Insomnia&logoColor=white)
![Badge](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
![Badge](https://img.shields.io/badge/microsoft%20azure-0089D6?style=for-the-badge&logo=microsoft-azure&logoColor=white)
![Badge](https://img.shields.io/badge/Azure%20Functions-blue?style=for-the-badge&logo=Azure%20Functions&logoColor=white)
![Badge](https://img.shields.io/badge/SonarQube-4E9BCD?style=for-the-badge&logo=SonarQube&logoColor=white)
![Badge](https://img.shields.io/badge/Horusec-orange?style=for-the-badge)
![Badge](https://img.shields.io/badge/MongoDB-white?style=for-the-badge&logo=mongodb&logoColor=4EA94B)
![Badge](https://img.shields.io/badge/Kibana-005571?style=for-the-badge&logo=Kibana&logoColor=white)
![Badge](https://img.shields.io/badge/Elastic_Search-005571?style=for-the-badge&logo=elasticsearch&logoColor=white)
![Badge](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Badge](https://img.shields.io/badge/PowerShell-5391FE?style=for-the-badge&logo=PowerShell&logoColor=white)

<hr>

  <h1 align="center">Projeto: Desafio 04 - Azure Serveless</h1>

<div align="center">
  <img style="border-radius:50px;" src="https://cdn2.downdetector.com/static/uploads/logo/image18.png" min-width="400px" max-width="400px" width="400px" alt="Azure">
  <br>
  <br>
  <br>
  <img style="border-radius:50px" src="https://uploads-ssl.webflow.com/6091713b6a00f546c5f59141/60917281100ec9f4a29cf107_Logo%20Vaivoa.png" min-width="400px" max-width="500px" width="400px" alt="Vaivoa">
</div>

## T??picos
* [Sobre o projeto](#sobre-o-projeto)
* [Desenvolvido com](#desenvolvido-com)
* [Como come??ar](#como-come??ar)
* [Pr??-requisitos](#pr??-requisitos)
* [Como usar](#como-usar)
* [SonarQube](#sonarqube)
* [Horusec](#horusec)
* [Imagens](#imagens)
* [Contribuidores](#contribuidores)

## Sobre o projeto

Este projeto foi desenvolvido com o intuito de utilizar e fixar os conhecimentos que foram vistos durante os cursos realizados neste per??odo de 3 semanas, com foco em aplicar o conceito de serverless computing, para isso foi desenvolvido na plataforma Azure uma function que recebe e armazena os logs de uma aplica????o pequena, desenvolvida para esse cen??rio especifico. De modo que esses logs ser??o estruturados e analisados para possibilitar a cria????o de um dashboard informativo utilizando o Kibana, e outros componentes da Elastic Stack.

[![Slide Badge](https://img.shields.io/badge/Apresenta????o%20Slides-0077B5?style=for-the-badge&logo=Google%20Drive&logoColor=white)](https://docs.google.com/presentation/d/1MEiuPHWa1635QHyPmpvyyo5jQNFIqrXGA4vWUXq4vV0)

O desafio foi idealizado pelo instrutor Eduardo Bueno, e constru??do inteiramente pelos integrantes do time, listados na ??ltima sess??o deste documento, utilizando as ferramentas da pr??xima sess??o em conjunto com as boas pr??ticas de programa????o e estrutura????o vistas nos cursos e pesquisas.


### Desenvolvido com

- .Net Core 5
- Azure Functions
- Elastic Stack
- Swagger
- Docker
- Docker Compose
- xUnity
- Github Actions
- Visual Studio 2019

## Como come??ar

Para come??ar com o projeto basta voc?? possuir em sua m??quina o Docker instalado e um navegador web ou ferramenta de chamadas Rest externa, como o Insomnia.

Talvez seja necess??rio a instala????o do certificado de desenvolvimento do .NET Core, para isso utilize os seguintes comandos:
```bash
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p suasenha
dotnet dev-certs https --trust
```
[Para mais informa????es do certificado](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide)

### Pr??-requisitos

Clonar o reposit??rio:

```bash
git clone https://github.com/Vaivoa/Turma-01-Desafio-4-Equipe-02.git
```

Para executar o ecossistema do projeto ?? necess??rio utilizar o Docker Compose usando o seguindo comando na pasta raiz do projeto:

```bash
docker-compose up
```

Em seguida ?? necessario iniciar a API e a Function dentro do VS ou pela CLI:

```bash
dotnet run
```

## Como usar

Para utilizar e testar o projeto acesse os endere??os abaixo:

```bash
http://localhost:5001/swagger/index.html        // Aplica????o API para consulta de endere??o, com foco em gerar Logs e m??tricas.
http://localhost:5601                           // Servidor Kibana
http://localhost:9200                           // Servidor Elasticsearch
http://localhost:7071                           // Azure Function
```
Na p??gina de OpenApi do Swagger voc?? poder?? enviar requisi????es para testes, ou tamb??m pode utilizar outras ferramentas para isso, como o insomnia.

### SonarQube

  * Pr??-requisitos
  
    * Para rodar o SonarQube, voc?? dever?? ter a vers??o 11 do [Java Development Kit](https://www.oracle.com/java/technologies/downloads/#java11-windows) instalada!

Em seguida, no seu terminal, navegue at?? a sua solu????o e crie um arquivo docker-compose.yml na raiz da solu????o com o comando

```bash
touch docker-compose.yml
```
Ap??s entrar no arquivo ``docker-compose.yml`` insira as seguintes configura????es que podem ser encontradas tamb??m [aqui](https://docs.sonarqube.org/latest/setup/install-server/):

<details>
<summary>Configura????es docker-compose.yml</summary>
    
```docker-compose.yaml
version: "3.4"

services:

  sonarqube:
    image: sonarqube:community
    container_name: sonarDesafio4
    depends_on:
      - db
    environment:
      SONAR_JDBC_URL: jdbc:postgresql://db:5432/sonar
      SONAR_JDBC_USERNAME: sonar
      SONAR_JDBC_PASSWORD: sonar
    volumes:
      - sonarqube_data:/opt/sonarqube/data
      - sonarqube_extensions:/opt/sonarqube/extensions
      - sonarqube_logs:/opt/sonarqube/logs
    ports:
      - "9000:9000"
      
  db:
    image: postgres:12
    container_name: postgresDesafio4
    environment:
      POSTGRES_USER: sonar
      POSTGRES_PASSWORD: sonar
    volumes:
      - postgresql:/var/lib/postgresql
      - postgresql_data:/var/lib/postgresql/data
      
  elasticsearch:
    container_name: elasticsearchDesafio4
    image: docker.elastic.co/elasticsearch/elasticsearch:7.15.0
    environment:
      - xpack.security.enabled=false
      - "discovery.type=single-node"
      - bootstrap.memory_lock=true
      - "ES_JAVA_OPTS=-Xms512m -Xmx512m"
    ulimits:
      memlock:
        soft: -1
        hard: -1
    networks:
      - es-net
    ports:
      - 9200:9200
    volumes:
      - es-data:/usr/share/elasticsearch/data
      
  kibana:
    container_name: kibanaDesafio4
    image: docker.elastic.co/kibana/kibana:7.15.0
    environment:
      - ELASTICSEARCH_HOSTS=http://elasticsearch:9200
    networks:
      - es-net
    depends_on:
      - elasticsearch
    ports:
      - 5601:5601
        
  apm-server:
    container_name: apmserverDesafio4
    image: docker.elastic.co/apm/apm-server:7.15.0
    depends_on:
      - elasticsearch
      - kibana
    cap_add: ["CHOWN", "DAC_OVERRIDE", "SETGID", "SETUID"]
    cap_drop: ["ALL"]
    ports:
    - 8200:8200
    networks:
    - es-net
    command: >
       apm-server -e
         -E apm-server.rum.enabled=true
         -E setup.kibana.host=kibana:5601
         -E setup.template.settings.index.number_of_replicas=0
         -E apm-server.kibana.enabled=true
         -E apm-server.kibana.host=kibana:5601
         -E output.elasticsearch.hosts=["elasticsearch:9200"]
      
networks:
  es-net:
    driver: bridge
 
volumes:
  sonarqube_data:
  sonarqube_extensions:
  sonarqube_logs:
  postgresql:
  postgresql_data:
  es-data:
```` 
  </details>

Em seguida vamos subir nossa imagem no Docker

```bash
docker-compose up
```

  * Importante :warning:

    Para executar o SonarQube no Docker, pode ser que a sua m??quina pe??a para voc?? aumentar o limite de mem??ria do WSL

    Para isso, abra o PowerShell e execute o seguinte comando para entrar na m??quina do WSL

    ```bash
    wsl -d docker-desktop
    ```
    Ap??s entrar na m??quina, execute o seguinte comando para aumentar a mem??ria:

    ```bash
    sysctl -w vm.max_map_count=262144
    ```
Perfeito, Docker Compose finalizado,SonarQube e PostgreSQL estar?? rodando!

Caso queira verificar a execu????o da imagem, v?? ao seu terminal e digite:
```bash
docker ps
```
ou tamb??m pelo [Docker Desktop](https://www.docker.com/products/docker-desktop)

Feito isso, abra no seu navegador ``http://localhost:9000``
> Aqui seguiremos no navegador

### Horusec

Primeiramente certifique-se de que o Docker est?? em execu????o em seu computador, agora para executar a verifica????o com o Horusec basta executar o seguinte comando dentro da pasta raiz do projeto.

```bash
docker run -v /var/run/docker.sock:/var/run/docker.sock --name Horusec -v ${PWD}:/src horuszup/horusec-cli:latest horusec start -p /src -P ${PWD}
```

## Imagens

<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/pRn1RRX/atlas.png">
    <br>
    <em>Estrutura do banco de dados do Atlas MongoDb. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/9W6TgHZ/elastic-index.png">
    <br>
    <em>Index do Elasticsearch usado para armazenar os dados de Logs. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/2PVLxzV/dokcer-compose.png">
    <br>
    <em>Docker Compose do projeto com as configura????es necess??rias para os containers. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/7Rchj8D/apm.png">
    <br>
    <em>Aplica????o configurada para gerar Logs e utilizar o APM da Elastic Stack para coletar m??tricas. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/GJFdqzX/solucao.png">
    <br>
    <em>Estrutura da solu????o incluindo a Aplica????o API e a Azure Function. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/q0QDpvt/function-local.png">
    <br>
    <em>Azure Function em funcionamento localmente. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/2gXGdKK/swagger-API.png">
    <br>
    <em>Apresenta????o da p??gina do Swagger (OpenAPI) da aplica????o API. </em>
</p>
<br>
<br>


## Contribuidores

[![Linkedin Badge](	https://img.shields.io/badge/Lucas%20Paes-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/lucastmp/)
[![Linkedin Badge](	https://img.shields.io/badge/Thone%20Cardoso-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/thonecardoso/)
[![Linkedin Badge](	https://img.shields.io/badge/Iury%20Ferreira-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/iury-ferreira-68ba35130/)
[![Linkedin Badge](	https://img.shields.io/badge/Gabriel%20Lopes-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/gabriellopees/)
[![Linkedin Badge](	https://img.shields.io/badge/Aecio%20Brito-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/aeciobrito/)
[![Linkedin Badge](	https://img.shields.io/badge/Eduardo%20Bueno-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/eduardobueno/)
