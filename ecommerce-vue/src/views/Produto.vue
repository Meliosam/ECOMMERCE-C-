<script setup>
import { ref, onMounted } from "vue";
import api from '../services/api.js';
 // Importando a API

const produto = ref([]);

const carregarProdutos = async () => {
  try {
    const response = await api.get("/produto");
    produtos.value = response.data;
  } catch (error) {
    console.error("Erro ao carregar produto:", error);
  }
};

onMounted(carregarProdutos);
</script>

<template>
  <div>
    <h1>Lista de Produtos</h1>
    <ul>
      <li v-for="produto in produtos" :key="produto.id">
        {{ produto.nome }} - R$ {{ produto.preco }}
      </li>
    </ul>
  </div>
</template>
