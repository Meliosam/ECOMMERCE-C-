<template>
  <div class="container">
    <h1>Lista de Produtos</h1>

    <!-- Formulário para Adicionar Produto -->
    <form @submit.prevent="adicionarProduto">
      <input v-model="novoProduto.nome" placeholder="Nome do Produto" required />
      <input v-model="novoProduto.preco" type="number" placeholder="Preço" required />
      <input v-model="novoProduto.descricao" placeholder="Descrição" />
      <input v-model="novoProduto.estoque" type="number" placeholder="Estoque" required />
      <button type="submit">Adicionar</button>
    </form>

    <!-- Lista de Produtos -->
    <ul>
      <li v-for="produto in produtos" :key="produto.id">
        <strong>{{ produto.nome }}</strong> - R$ {{ produto.preco.toFixed(2) }}
        <p>{{ produto.descricao }}</p>
        <p>Estoque: {{ produto.estoque }}</p>
        <button @click="removerProduto(produto.id)">Remover</button>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted } from "vue";
import api from "../services/api.js";

// Lista de produtos
const produtos = ref([]);

// Novo produto a ser adicionado
const novoProduto = ref({
  nome: "",
  preco: 0,
  descricao: "",
  estoque: 0,
});

// Carregar produtos ao montar o componente
const carregarProdutos = async () => {
  try {
    const response = await api.getProdutos();
    produtos.value = response.data;
  } catch (error) {
    console.error("Erro ao carregar produtos:", error);
  }
};

// Adicionar novo produto
const adicionarProduto = async () => {
  if (!novoProduto.value.nome || novoProduto.value.preco <= 0) {
    alert("Preencha os campos corretamente!");
    return;
  }

  try {
    await api.addProduto(novoProduto.value);
    novoProduto.value = { nome: "", preco: 0, descricao: "", estoque: 0 };
    carregarProdutos();
  } catch (error) {
    console.error("Erro ao adicionar produto:", error);
  }
};

// Remover produto
const removerProduto = async (id) => {
  try {
    await api.deleteProduto(id);
    carregarProdutos();
  } catch (error) {
    console.error("Erro ao remover produto:", error);
  }
};

// Carrega os produtos ao iniciar
onMounted(carregarProdutos);
</script>

<style scoped>
.container {
  max-width: 600px;
  margin: auto;
  text-align: center;
}

form {
  display: flex;
  flex-direction: column;
  gap: 10px;
  margin-bottom: 20px;
}

input {
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

button {
  padding: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #0056b3;
}

ul {
  list-style: none;
  padding: 0;
}

li {
  border: 1px solid #ccc;
  padding: 10px;
  margin-bottom: 10px;
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  gap: 5px;
}
</style>
