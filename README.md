# 🛒 Lista de Compras

> Sistema web desenvolvido em ASP.NET MVC para organizar compras de forma prática e eficiente — nunca mais esquecer um item ou comprar o que já tem em casa!

<br>

## 👥 Desenvolvedores

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/pedrohenriquedsdev">
        <img src="https://github.com/pedrohenriquedsdev.png" width="80px" style="border-radius: 50%"/><br/>
        <sub><b>Pedro Henrique</b></sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/Marco-Oliver">
        <img src="https://github.com/Marco-Oliver.png" width="80px" style="border-radius: 50%"/><br/>
        <sub><b>Marco Oliver</b></sub>
      </a>
    </td>
  </tr>
</table>

<br>

## 📋 Sobre o Projeto

Maria faz as compras da família toda semana, mas sempre esquece algum item ou compra coisas que já tem em casa. Para resolver esse problema, foi criado o **Lista de Compras** — um sistema simples e organizado para cadastrar produtos, montar listas e registrar as compras realizadas.

<br>

## ✨ Funcionalidades

### 🏷️ Módulo de Categorias
- Cadastrar, editar, visualizar e excluir categorias
- Cada categoria possui nome (único, até 50 caracteres) e cor personalizada
- Não é possível excluir uma categoria que possui produtos vinculados

### 📦 Módulo de Produtos
- Cadastrar, editar, visualizar e excluir produtos
- Campos: nome, categoria, unidade de medida (kg, unidade, litro, caixa...) e preço aproximado
- Não permite produtos com o mesmo nome dentro da mesma categoria

### 📝 Módulo de Listas de Compras
- Criar, editar, visualizar e excluir listas
- Cada lista possui nome, data de criação automática e status (Aberta / Concluída)
- Exibe total de itens e valor estimado total por lista
- Não é possível excluir uma lista que já possui itens

### 🛍️ Módulo de Itens da Lista
- Adicionar e remover produtos de uma lista
- Exibe a categoria do produto ao selecioná-lo
- Calcula automaticamente o valor total da lista (preço × quantidade)
- Não permite adicionar o mesmo produto duas vezes na mesma lista

<br>

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- Git

### Passo a passo

```bash
# 1. Clone o repositório
git clone https://github.com/pedrohenriquedsdev/lista-de-compras.git

# 2. Acesse a pasta do projeto
cd lista-de-compras

# 3. Restaure os pacotes
dotnet restore

# 4. Execute a aplicação
dotnet run --project src/ListaDeCompras.Web
```

Acesse no navegador: `https://localhost:5001`

> Os dados são persistidos em arquivo local — nenhuma configuração de banco de dados é necessária.

<br>

## 🎬 Demonstração

> *(Adicione aqui um GIF ou vídeo demonstrando as principais telas do sistema)*

<!-- Exemplo:
![Demo da aplicação](docs/demo.gif)
-->

<br>

## 🏗️ Arquitetura

O projeto segue o padrão de **3 camadas** com ASP.NET MVC:

```
ListaDeCompras/
├── src/
│   ├── ListaDeCompras.Web/          # Camada de Apresentação (Controllers, Views, ViewModels)
│   │   ├── Controllers/
│   │   │   ├── Categorias/
│   │   │   ├── Produtos/
│   │   │   ├── Listas/
│   │   │   └── Itens/
│   │   └── Views/
│   │       ├── Categorias/
│   │       ├── Produtos/
│   │       ├── Listas/
│   │       └── Itens/
│   ├── ListaDeCompras.Domain/        # Camada de Domínio (Entidades, Regras de Negócio)
│   │   ├── Entities/
│   │   └── Services/
│   └── ListaDeCompras.Infrastructure/ # Camada de Infraestrutura (Persistência em Arquivo)
│       └── Repositories/
└── README.md
```

<br>

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Uso |
|---|---|
| ASP.NET MVC (.NET 8) | Framework principal |
| C# | Linguagem de programação |
| Razor / TagHelpers | Renderização de views |
| DataAnnotations | Validações de formulário |
| AutoMapper | Mapeamento entre entidades e ViewModels |
| Injeção de Dependência | Baixo acoplamento entre camadas |
| Serialização em arquivo (JSON) | Persistência de dados |
| Bootstrap | Estilização da interface |

<br>

## ✅ Boas Práticas Aplicadas

- Separação clara em **3 camadas** (Apresentação, Domínio, Infraestrutura)
- **ViewModels** para comunicação com as Views; **Records** para DTOs imutáveis
- **Services** concentrando as regras de negócio
- **Extension Methods** para comportamentos reutilizáveis
- **Delegates, métodos anônimos e Lambdas** para maior legibilidade
- **TempData** para feedback entre requisições
- **ModelState** para validação consistente dos formulários
- Nomenclatura seguindo o padrão **PascalCase / camelCase**
- Tratamento de exceções e validações robustos

<br>

## 📌 Regras de Negócio Principais

- Categorias com nomes duplicados não são permitidas
- Produtos com o mesmo nome na mesma categoria não são permitidos
- Uma categoria não pode ser excluída se tiver produtos vinculados
- Uma lista não pode ser excluída se tiver itens vinculados
- O mesmo produto não pode aparecer duas vezes na mesma lista
- O valor total da lista é calculado automaticamente

<br>

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais na **Academia do Programador**.

---

<p align="center">
  Desenvolvido por
  <a href="https://github.com/pedrohenriquedsdev">Pedro Henrique</a> &
  <a href="https://github.com/Marco-Oliver">Marco Oliver</a>
</p>