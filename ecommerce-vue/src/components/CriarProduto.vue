<template>
  <div>
    <h2>Criar Produto</h2>
    <form @submit.prevent="criarProduto">
      <label>Nome:</label>
      <input v-model="produto.nome" required />

      <label>Preço:</label>
      <input type="number" v-model="produto.preco" required />

      <label>Descrição:</label>
      <textarea v-model="produto.descricao" required></textarea>

      <label>Estoque:</label>
      <input type="number" v-model="produto.estoque" required />

      <button type="submit">Criar</button>
    </form>
  </div>
</template>

<script>
import api from '../services/api.js';

export default {
  data() {
    return {
      produto: {
        nome: "",
        preco: 0,
        descricao: "",
        estoque: 0,
      },
    };
  },
  methods: {
    async criarProduto() {
      try {
        await api.post("/Produto", this.produto);
        alert("Produto criado com sucesso!");
      } catch (error) {
        console.error("Erro ao criar produto:", error);
      }
    },
  },
};
</script>
