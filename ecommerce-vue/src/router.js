import { createRouter, createWebHistory } from "vue-router";
import Produtos from "./views/Produto.vue";
import CriarProduto from "./components/CriarProduto.vue";

const routes = [
  { path: "/", component: Produtos },
  { path: "/criar", component: CriarProduto },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
