# 🛒 LISTA DE COMPRAS | Sistema de Gestão de Compras Residências 🚀

> **Controle inteligente de categorias, produtos e listas para organizar as compras da família.**

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Razor CSHTML](https://img.shields.io/badge/Razor_CSHTML-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Arquitetura MVC](https://img.shields.io/badge/Architecture-MVC-blue?style=for-the-badge)
![Desenvolvimento Web](https://img.shields.io/badge/Dev-Web-orange?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Concluído-brightgreen?style=for-the-badge)

---

![alt text](image.png)

# 📌 Sobre o Projeto

O **Lista de Compras** foi desenvolvido para ajudar a Maria a organizar as compras da família semanalmente, evitando o esquecimento de itens essenciais ou a compra duplicada de produtos que já existem em estoque doméstico.

---

### 🗂️ Módulo de Categorias
> **Ações Suportadas:** `Cadastrar` | `Editar` | `Excluir` | `Visualizar`

| Parâmetro | Regra de Negócio |
| :--- | :--- |
| **Identificação** | Nome obrigatório, único e com limite máximo de 50 caracteres. |
| **Customização** | Definição de Cor através de seleção de paleta ou código Hexadecimal. |
| **Segurança** | Bloqueio automático de exclusão se houver produtos vinculados à categoria. |

---

### 📦 Módulo de Produtos
> **Ações Suportadas:** `Cadastrar` | `Editar` | `Excluir` | `Visualizar`

| Parâmetro | Regra de Negócio |
| :--- | :--- |
| **Validação** | Nome obrigatório (2 a 100 caracteres) e combinação única de Nome + Categoria. |
| **Vínculo** | Associação obrigatória a uma categoria previamente cadastrada. |
| **Métricas** | Definição obrigatória da unidade de medida (kg, un, L, cx) e preço aproximado. |

---

### 📝 Módulo de Listas de Compras
> **Ações Suportadas:** `Criar` | `Editar` | `Excluir` | `Visualizar`

| Parâmetro | Regra de Negócio |
| :--- | :--- |
| **Identificação** | Nome da lista obrigatório (3 a 100 caracteres) e data de criação automática. |
| **Status** | Controle de ciclo de vida da lista de compras: `Aberta` \| `Concluída`. |
| **Restrições** | Bloqueio de exclusão se houver itens vinculados; exibição de totalizadores. |

---

### 🍎 Módulo de Itens da Lista
> **Ações Suportadas:** `Adicionar Item` | `Remover Item` | `Visualizar Itens`

| Parâmetro | Regra de Negócio |
| :--- | :--- |
| **Vínculo** | Seleção obrigatória do produto com exibição visual de sua categoria. |
| **Quantidade** | Definição de quantidade estritamente positiva (maior que zero). |
| **Cálculos** | Impede produtos duplicados na mesma lista; calcula valor estimado total automaticamente. |

---

# 🧠 Conceitos Aplicados

| Conceito | Aplicação |
|---|---|
| 🏗️ POO | Modelagem das entidades físicas e lógicas do sistema de compras |
| 📐 Camadas | Separação estrita de responsabilidades (MVC) |
| ⚙️ Regras | Validação robusta contra duplicidade de produtos e exclusões indevidas |

## 👨‍💻 Autores

<div align="center">

Desenvolvido por **Alunos da Academia do Programador**.

[![GitHub](https://img.shields.io/badge/GitHub-pedrohenriquedsdev-181717?style=for-the-badge&logo=github)](https://github.com/pedrohenriquedsdev)

[![GitHub](https://img.shields.io/badge/GitHub-Marco--Oliver-181717?style=for-the-badge&logo=github)](https://github.com/Marco-Oliver)

</div>