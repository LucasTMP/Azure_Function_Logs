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

## Tópicos
* [Sobre o projeto](#sobre-o-projeto)
* [Desenvolvido com](#desenvolvido-com)
* [Como começar](#como-começar)
* [Pré-requisitos](#pré-requisitos)
* [Como usar](#como-usar)
* [SonarQube](#sonarqube)
* [Horusec](#horusec)
* [Imagens](#imagens)
* [Contribuidores](#contribuidores)

## Sobre o projeto

Este projeto foi desenvolvido com o intuito de utilizar e fixar os conhecimentos que foram vistos durante os cursos realizados neste período de 3 semanas, com foco em aplicar o conceito de serverless computing, para isso foi desenvolvido na plataforma Azure uma function que recebe e armazena os logs de uma aplicação pequena, desenvolvida para esse cenário especifico. De modo que esses logs serão estruturados e analisados para possibilitar a criação de um dashboard informativo utilizando o Kibana, e outros componentes da Elastic Stack.

[![Slide Badge](https://img.shields.io/badge/Apresentação%20Slides-0077B5?style=for-the-badge&logo=Google%20Drive&logoColor=white)](https://docs.google.com/presentation/d/1MEiuPHWa1635QHyPmpvyyo5jQNFIqrXGA4vWUXq4vV0)

O desafio foi idealizado pelo instrutor Eduardo Bueno, e construído inteiramente pelos integrantes do time, listados na última sessão deste documento, utilizando as ferramentas da próxima sessão em conjunto com as boas práticas de programação e estruturação vistas nos cursos e pesquisas.


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

## Como começar

Para começar com o projeto basta você possuir em sua máquina o Docker instalado e um navegador web ou ferramenta de chamadas Rest externa, como o Insomnia.

Talvez seja necessário a instalação do certificado de desenvolvimento do .NET Core, para isso utilize os seguintes comandos:
```bash
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p suasenha
dotnet dev-certs https --trust
```
[Para mais informações do certificado](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide)

### Pré-requisitos

Clonar o repositório:

```bash
git clone https://github.com/Vaivoa/Turma-01-Desafio-4-Equipe-02.git
```

Para executar o ecossistema do projeto é necessário utilizar o Docker Compose usando o seguindo comando na pasta raiz do projeto:

```bash
docker-compose up
```

Em seguida é necessario iniciar a API e a Function dentro do VS ou pela CLI:

```bash
dotnet run
```

## Como usar

Para utilizar e testar o projeto acesse os endereços abaixo:

```bash
http://localhost:5001/swagger/index.html        // Aplicação API para consulta de endereço, com foco em gerar Logs e métricas.
http://localhost:5601                           // Servidor Kibana
http://localhost:9200                           // Servidor Elasticsearch
http://localhost:7071                           // Azure Function
```
Na página de OpenApi do Swagger você poderá enviar requisições para testes, ou também pode utilizar outras ferramentas para isso, como o insomnia.

### SonarQube

  * Pré-requisitos
  
    * Para rodar o SonarQube, você deverá ter a versão 11 do [Java Development Kit](https://www.oracle.com/java/technologies/downloads/#java11-windows) instalada!

Em seguida, no seu terminal, navegue até a sua solução e crie um arquivo docker-compose.yml na raiz da solução com o comando

```bash
touch docker-compose.yml
```
Após entrar no arquivo ``docker-compose.yml`` insira as seguintes configurações que podem ser encontradas também [aqui](https://docs.sonarqube.org/latest/setup/install-server/):

<details>
<summary>Configurações docker-compose.yml</summary>
    
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

    Para executar o SonarQube no Docker, pode ser que a sua máquina peça para você aumentar o limite de memória do WSL

    Para isso, abra o PowerShell e execute o seguinte comando para entrar na máquina do WSL

    ```bash
    wsl -d docker-desktop
    ```
    Após entrar na máquina, execute o seguinte comando para aumentar a memória:

    ```bash
    sysctl -w vm.max_map_count=262144
    ```
Perfeito, Docker Compose finalizado,SonarQube e PostgreSQL estará rodando!

Caso queira verificar a execução da imagem, vá ao seu terminal e digite:
```bash
docker ps
```
ou também pelo [Docker Desktop](https://www.docker.com/products/docker-desktop)

Feito isso, abra no seu navegador ``http://localhost:9000``
> Aqui seguiremos no navegador

### Horusec

Primeiramente certifique-se de que o Docker está em execução em seu computador, agora para executar a verificação com o Horusec basta executar o seguinte comando dentro da pasta raiz do projeto.

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
    <em>Docker Compose do projeto com as configurações necessárias para os containers. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/7Rchj8D/apm.png">
    <br>
    <em>Aplicação configurada para gerar Logs e utilizar o APM da Elastic Stack para coletar métricas. </em>
</p>
<hr>
<p align="center" width="100%">
    <img width="33%" src="https://i.ibb.co/GJFdqzX/solucao.png">
    <br>
    <em>Estrutura da solução incluindo a Aplicação API e a Azure Function. </em>
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
    <em>Apresentação da página do Swagger (OpenAPI) da aplicação API. </em>
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
