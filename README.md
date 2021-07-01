# Softplan.CalculadoraJuros
Projeto de seleção para a Softplan

### Ambiente de desenvolvimento do Projeto
Este projeto foi desenvolvido em C#, através do Visual Studio 2019 para Windows, utilizando o Dotnet Core 5.0 e Dotnet Standard 2.1.

Sua publicação em debug ou release é voltada para Docker, utilizando o Docker Desktop no Windows 10.

### Objetivos do projeto
Este projeto tem como objetivo realizar o cálculo de juros composto através de um período de meses. Para atender esse objetivo, ele se baseia em duas demandas principais.
- Desenvolvimento de uma API que retorna a taxa de juros atual. Esta taxa de juros é configurada de forma fixada em 1%.
- Desenvolver uma API que calcula o valor final em que incidirá juros. Para isso ela consome a api de Taxa de Juros.

### Diagrama de Container
![Imagem Diagrama 01](https://raw.githubusercontent.com/RogerGelonezi/Softplan.CalculadoraJuros/master/docs/diagrama-imagem-01.png)
- O usuário poderá acessar uma UI, essa UI se comunicará com a API de taxa de juros.
- O usuário poderá acessar uma UI, essa UI se comunicará com a API de calculo de juros, que por sua vez, se comunicará com a API de taxa de juros.

### Diagrama de Componentes API Taxa de Juros
![Imagem Diagrama 02](https://raw.githubusercontent.com/RogerGelonezi/Softplan.CalculadoraJuros/master/docs/diagrama-imagem-02.png)
- O usuário poderá acessar uma UI, essa UI se comunicará com a API de taxa de juros que lhe retornará uma resposta JSON com o valor multiplicador da taxa atual.

### Diagrama de Componentes API de Cálculo de Juros
![Imagem Diagrama 03](https://raw.githubusercontent.com/RogerGelonezi/Softplan.CalculadoraJuros/master/docs/diagrama-imagem-03.png)
- O usuário poderá acessar uma UI, essa UI se comunicará com a API de cálculo de juros, que lhe retornará um JSON com o valor calculado com o juros. Essa API de calculadora pesquisará informações dentro da API de Taxa de Juros, e também utilizará de um serviço Handler do projeto para a realização do cálculo.

### Diagrama de Deployment
![Imagem Diagrama 04](https://raw.githubusercontent.com/RogerGelonezi/Softplan.CalculadoraJuros/master/docs/diagrama-imagem-04.png)
- O usuário poderá acessar uma UI, essa UI se comunicará com as APIs, que por sua vez, estarão cada uma publicadas em um ambiente Docker.

### Restrições
O projeto possui tarifa fixa de juros, ele não é capaz de calcular juros voláteis, como por exemplo, juros baseados nos índices da SELIC.

### Executando o Projeto no Visual Studio
Visto que você já tenha todo o *Ambiente de desenvolvimento do Projeto* preparado, siga os passos.
- Obs.: Atenção para o Docker estar em execução.
- No Visual Studio, Defina o projeto Softplan.CalculadoraJuros.TaxaApi como projeto inicial e o execute sem debug. [CTRL + F5]. Isso iniciará o sistema e abrirá o Swagger como home page.
- Descubra o seu IP. Isso pode ser feito através do Prompt de Comando do Windows, executando o comando ipconfig. Vamos precisar do seu Endereço IPv4.
- Através do browser, teste o acesso ao endpoint da Taxa de juros utilizando o seu IPv4 no lugar do LocalHost. No meu caso, por exemplo, seria em https://192.168.56.1:49153/api/TaxaJuros
- No Visual Studio, projeto Softplan.CalculadoraJuros.CalculadoraApi, vá até o arquivo appsettings.json e substitua a configuração EndpointApiTaxaJuros pelo seu endpoint. Atenção: seu endpoint deve terminar em "...api/".
- Agora defina o projeto Softplan.CalculadoraJuros.CalculadoraApi como projeto inicial do Visual Studio, inicie ele sem debug [CTRL + F5], e você estará pronto para utilizar o sistema.
- Para facilitar, todo o projeto foi configurado para utilizar o Swagger. Você poderá acessá-lo em https://[seu_ip_e_porta]/swagger/index.html

### Executando o projeto diretamente no Docker for Windows
Com o Docker rodando, abra o seu terminal favorito, execute as seguintes linhas de comando:
```
docker run -p 49161:80 --name TaxaApi -d rogeriogelonezi/softplancalculadorajurostaxaapi
docker run -p 49169:80 --name CalculadoraJuros -d rogeriogelonezi/softplancalculadorajuroscalculadoraapi
```
```
docker network create --subnet=172.18.0.0/16 softplan
docker network connect --ip 172.18.0.11 softplan TaxaApi
docker network connect --ip 172.18.0.12 softplan CalculadoraJuros
```
Agora acesso do seu browser
```
http://localhost:49169/swagger/index.html
```
### Gerando nova versão
Antes de gerar nova versão e enviar para o Hub.Docker, no projeto Softplan.CalculadoraJuros.CalculadoraApi, você deve alterar o arquivo appsetings.json, campo EndpointApiTaxaJuros deverá ter o valor "http://172.18.0.11:80/api/".

### Considerações ao avaliador
O projeto foi desenvolvido obedecendo as boas práticas dos conceitos SOLID, injeção de dependência, e TDD.

Antes de iniciar o projeto eu não possuia muita experiência com testes automatizados, havia trabalhado com testes em 2014, e estes eram voltados apenas para garantir o correto mapeamento do banco de dados e nHibernate. Com dois cursos que fiz na Alura, percebi o quão importante era ele e como eu deveria tê-lo priorizado há tempos. Então só por isso, já tenho o que agradecer pela oportunidade de participar desta seleção, espero que eu possa receber e compartilhar muito mais com vocês no futuro.
