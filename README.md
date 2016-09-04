# AskNGo - Fóruns Inteligentes

## Proposta

Nossa idéia é resolver o problema de atraso no tempo de respostas nos fóruns de dúvidas do Moodle. Com uma API inteligente, que entende a resposta do usuário e sugere - com base em técnicas de recuperação de informação e aprendizado de máquina - discussões que já aconteceram anteriormente, a partir do banco de dados histórico da disciplina.

## Projeto

O esboço inicial do projeto foi desenvolvido durante a Hackathon DCC 40 Anos, pelos alunos Allan Sene, Carlos Ferreira, Gabriel Capanema, Gabriel Cardoso e Wagner Teixeira. Para uma idéia geral de nossa proposta, veja [nossa apresentação](https://www.canva.com/design/DAB9VLDvzeg/Njm_8Nlok8jv1h1kw6rtrA/view?utm_content=DAB9VLDvzeg&utm_campaign=designshare&utm_medium=link&utm_source=sharebutton) feita ao fim da competição.

## Arquitetura

### Backend

A arquitetura inicial levantada, considera 3 blocos essenciais para o funcionamento da aplicação. Tais blocos são:
* Máquina/Container com o ElasticSearch, expondo sua API Rest
* Máquina/Container com o Serviço desenvolvido, o AskNGo, expondo as operações de CRUD de novos documentos (api/Document) e Busca Inteligente (api/Search)
* Máquina/Container com a aplicação de apresentação, neste caso, o UFMG Overflow, desenvolvido sobre a plataforma Meteor.

Este último item pode ser substituído por qualquer módulo que integre com o Fórum, por exemplo, um plugin para o Moodle, como foi nossa proposta inicial. 

Segue o esquema abaixo:

#### Esquema arquitetural do Backend
![Esquema arquitetural do Backend](integracao-back.jpg)

#### Esquema arquitetural da integração API/Front-end
![Esquema arquitetural da integração API/Front-end](integracao-front.jpg)