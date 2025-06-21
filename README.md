# Desafio backend

## 📐 Diagrama de Classes

Abaixo está o diagrama de classes representando as entidades da aplicação:

![motohub-Diagrama de dominio drawio](https://github.com/user-attachments/assets/32ce8a53-f5fb-4a8c-bd45-d9faf76174c9)

## 🛠️ Como Rodar a Aplicação com Docker Compose
Este projeto utiliza Docker e Docker Compose para facilitar a execução da API e do banco de dados PostgreSQL em containers.

---

## ✅ Pré-requisitos

- [Docker Desktop](https://www.docker.com/products/docker-desktop) instalado e em execução.
- [Git](https://git-scm.com/) instalado.
- A porta `8080` (API) e `5432` (PostgreSQL) devem estar livres.

---

## 📦 Passo a Passo

### 1. Clone o repositório

- git clone https://github.com/lucs-sb/Desafio-BackEnd.git
- cd Desafio-BackEnd

### 2. Execute os containers

docker compose up -d --build

### 3. Parar os containers

docker compose down
